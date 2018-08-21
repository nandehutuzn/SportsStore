using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> _lineCollection = new List<CartLine>();

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product, int quantity)
        {
            CartLine line = _lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
                _lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            else
                line.Quantity += quantity;
        }

        /// <summary>
        /// 移除商品
        /// </summary>
        /// <param name="product"></param>
        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        /// <summary>
        /// 计算商品总价
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        public void Clear()
        {
            _lineCollection.Clear();
        }

        /// <summary>
        /// 购物车所有商品
        /// </summary>
        public IEnumerable<CartLine> Lines {
            get { return _lineCollection; }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
