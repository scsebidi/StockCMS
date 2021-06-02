﻿using SiphoCoreApi.Contex;
using SiphoCoreApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiphoCoreApi.Implimentation
{
    public class StockData : IStock
    {
        private DBContext _db;

        public StockData(DBContext db) {
            _db = db;
        }
        public StockItemModel AddStock(StockItemModel stock)
        {
            try
            {
                stock.id = Guid.NewGuid();
                stock.images.Id = Guid.NewGuid();
                stock.Accessory.Id = Guid.NewGuid();
                _db.StockItem.Add(stock);
                _db.SaveChanges();
                return stock;
            }
            catch (Exception)
            {

                throw;
            }
        }

      
        public List<StockItemModel> GetStockItems()
        {
            var Stock = _db.StockItem.ToList();
            return Stock;
        }

        public StockItemModel UpdateStock(StockItemModel stockItem)
        {
            try
            {
               var stock =  _db.StockItem.Find(stockItem.id);
                if (stock != null) {
                    _db.StockItem.Update(stockItem);
                }
                return stockItem;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public StockItemModel GetBy(Guid id)
        {
            var stock = _db.StockItem.Find(id);
            return stock;
        }

        public void DeleteStock(StockItemModel stock)
        {
            _db.StockItem.Remove(stock);
            _db.SaveChanges();
        }
    }
}
