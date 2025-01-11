﻿using Microsoft.AspNetCore.Mvc;
using RabbitMqDemo.Models;
using RabbitMqDemo.RabbitMQ;
using RabbitMqDemo.Services;

namespace RabbitMqDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;
		private readonly IRabbitMQProducer _rabbitMQProducer;

		public ProductController(IProductService _productService, IRabbitMQProducer rabbitMQProducer)
		{
			productService = _productService;
			_rabbitMQProducer = rabbitMQProducer;
		}

		[HttpGet("productlist")]
		public IEnumerable<Product> ProductList()
		{
			var productList = productService.GetProductList();
			return productList;
		}

		[HttpGet("getproductbyid")]
		public Product GetProductById(int Id)
		{
			return productService.GetProductById(Id);
		}

		[HttpPost("addproduct")]
		public Product AddProduct(Product product)
		{
			var productData = productService.AddProduct(product);
			//send the inserted product data to the queue and consumer will listening this data from queue
			_rabbitMQProducer.SendProductMessage(productData);
			return productData;
		}

		[HttpPut("updateproduct")]
		public Product UpdateProduct(Product product)
		{
			return productService.UpdateProduct(product);
		}

		[HttpDelete("deleteproduct")]
		public bool DeleteProduct(int Id)
		{
			return productService.DeleteProduct(Id);
		}
	}
}
