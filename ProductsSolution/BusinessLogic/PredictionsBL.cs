﻿using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PredictionsBL : IPredictionsBL
    {
        IRepository<Prediction> repositoryPredictions;
        IRepository<Product> repositoryProduct;
        IRepository<SalePoint> repositorySalePoint;
        IRepository<Stock> repositoryStock;
        IRepository<Country> repositoryCountry;

        public PredictionsBL(IRepository<Prediction> _repositoryPredictions, 
            IRepository<Product> _repositoryProduct, 
            IRepository<SalePoint> _repositorySalePoint,
            IRepository<Stock> _repositoryStock,
            IRepository<Country> _repositoryCountry)
        {
            this.repositoryPredictions = _repositoryPredictions ?? throw new ArgumentNullException(nameof(_repositoryPredictions));
            this.repositoryProduct = _repositoryProduct;
            this.repositorySalePoint = _repositorySalePoint;
            this.repositoryStock = _repositoryStock;
            this.repositoryCountry = _repositoryCountry;
        }

        public bool DeletePrediction(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PredictionDTO>> GetPredictionsByProductId(int productId, int countryId)
        {
            IEnumerable<PredictionDTO> predictions = from s in repositoryPredictions.GetQuery()
                                                  join p in repositoryProduct.GetQuery() on s.ProductId equals p.Id
                                                  join sp in repositorySalePoint.GetQuery() on s.salepointid equals sp.Id
                                                  join co in this.repositoryCountry.GetQuery() on sp.CountryId equals co.Id
                                                  where p.Id == productId && co.Id == countryId && s.applied == false
                                                  orderby s.Id
                                                  select new PredictionDTO
                                                  {
                                                      Id = s.Id,
                                                      salepointid = s.salepointid,
                                                      productid = s.ProductId,
                                                      product = p.Description,
                                                      salepoint = sp.Description,
                                                      amount = s.amount,
                                                      date = s.date,
                                                      day = s.day,
                                                      month = s.month,
                                                      year = s.year,
                                                      applied = s.applied
                                                  };

            return predictions.ToList();
        }

        public async Task<IList<PredictionDTO>> GetAllPredictions()
        {
            var predictionsAsync = await repositoryPredictions.GetAllAsync();
            var productsAsync = await repositoryProduct.GetQueryAsync();
            var salepointAsync = await repositorySalePoint.GetAllAsync();

            IEnumerable<PredictionDTO> searches = from s in predictionsAsync
                                              join p in productsAsync on s.ProductId equals p.Id
                                              join sp in salepointAsync on s.salepointid equals sp.Id
                                              orderby s.Id
                                              select new PredictionDTO
                                              {
                                                  Id = s.Id,
                                                  salepointid = s.salepointid,
                                                  productid = s.ProductId,
                                                  product = p.Description,
                                                  salepoint = sp.Description,
                                                  amount = s.amount,
                                                  date = s.date,
                                                  day = s.day,
                                                  month = s.month,
                                                  year = s.year,
                                                  applied = s.applied
                                              };

            return searches.ToList();
        }

        public PredictionDTO GetPredictionById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save(PredictionDTO prediction)
        {
            throw new NotImplementedException();
        }
        public bool ApplyAllPredictionsNoAsync()
        {
            try
            {
                var listPredictions = repositoryPredictions.GetAll();

                var listToApplied = listPredictions.Where(x => !x.applied).ToList();

                foreach (var pred in listToApplied)
                {
                    //find the stock for this prediction
                    var list = repositoryStock.GetAll();
                    var stock = list.Where(x => x.ProductId == pred.ProductId && x.SalePointId == pred.salepointid).FirstOrDefault();

                    var dif = Math.Abs(stock.Amount - (pred.amount * 1.2));
                    stock.Amount += Convert.ToInt32(dif);
                    //stock.Amount += pred.amount;

                    this.repositoryStock.Save(stock);

                    pred.applied = true;
                    this.repositoryPredictions.Save(pred);

                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> applyByProductIdCountryId(int productid, int countryorigenid, int countryDestinoid, int amount) {

            var stocks = await this.repositoryStock.GetAllAsync();
            var salePoints = await this.repositorySalePoint.GetAllAsync();
            var salePointOrigen = salePoints.Where(x => x.Id == countryorigenid).FirstOrDefault();
            var salePointDestino = salePoints.Where(x => x.Id == countryDestinoid).FirstOrDefault();

            var stockOrigen = stocks.Where(x => x.SalePointId == salePointOrigen.Id && x.ProductId == productid).FirstOrDefault();
            var stockDestino = stocks.Where(x => x.SalePointId == salePointDestino.Id && x.ProductId == productid).FirstOrDefault();

            stockOrigen.Amount += amount;
            stockDestino.Amount -= amount;

            this.repositoryStock.Save(stockDestino);
            this.repositoryStock.Save(stockOrigen);
            return true;
        }

        public async Task<bool> ApplyAllPredictions()
        {
            try
            {
                var listPredictions = await repositoryPredictions.GetAllAsync();

                var listToApplied = listPredictions.Where(x => !x.applied).ToList();

                foreach (var pred in listToApplied)
                {
                    //find the stock for this prediction
                    var list = await repositoryStock.GetAllAsync();
                    var stock = list.Where(x => x.ProductId == pred.ProductId && x.SalePointId == pred.salepointid).FirstOrDefault();
                    stock.Amount += pred.amount;

                    this.repositoryStock.Save(stock);

                    pred.applied = true;
                    this.repositoryPredictions.Save(pred);

                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
