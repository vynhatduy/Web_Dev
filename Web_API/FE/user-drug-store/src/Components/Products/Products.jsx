import React, { useState, useEffect } from "react";
import data from "./Products.js";
import "./Products.css";
// import api from'-drug-store/api.js';
import request from "superagent";

const GetProduct = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const api = "https://localhost:7258/api/SanPhams";
        const response = await request.get(api);
        setProducts(response.body);
      } catch (error) {
        console.error(error);
        return null;
      }
    };

    fetchProducts();
  }, []);

  return products;
};

const GetCategories=()=>{
    const [category,SetCategory]=useState([]);
    useEffect(()=>{
        const fetchCategories = async ()=>{
            try{
                const api="https://localhost:7258/api/DanhMucs";
                const response=await request.get(api);
                SetCategory(response.body);
            }
            catch(error){
                console.log(error);
                return null;
            }
        };
        fetchCategories();
    },[]);
    return category;
}

export const Products = () => {
  const categorys = GetCategories();
  const products = GetProduct();
  if(categorys.length==0||products.length==0){
    <div className="products">
    <div className="container">
      <div className="row">
        <div className="col-3">
          <div className="category-list">
            <h3>Lỗi dữ liệu</h3>
          </div>
        </div>
        <div className="col-9">
            <div className="product-list">
              <h3>Lỗi dữ liệu</h3>
            </div>
          </div>
        </div>
      </div>
    </div>
  }
  if(categorys.length==0){
    return(
    <div className="products">
      <div className="container">
        <div className="row">
          <div className="col-3">
            <div className="category-list">
              <h3>Lỗi dữ liệu</h3>
            </div>
          </div>
          <div className="col-9">
            <div className="product-list">
              {products.map((products) => (
                <div key={products.id} className="product-item">
                  <img src={products.url} alt={products.ten} />
                  <label>{products.ten}</label>
                  <p>{products.gia} VND</p>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </div>
    );
  }
  if(products.length==0){
    <div className="products">
      <div className="container">
        <div className="row">
          <div className="col-3">
            <div className="category-list">
              {categorys.map((categorys) => (
                <div key={categorys.id} className="danh-muc-item">
                  <h5>{categorys.ten}</h5>
                </div>
              ))}
            </div>
          </div>

          <div className="col-9">
            <div className="product-list">
              <h3>Lỗi dữ liệu</h3>
            </div>
          </div>
        </div>
      </div>
    </div>
  }
  return (
    <div className="products">
      <div className="container">
        <div className="row">
          <div className="col-3">
            <div className="category-list">
              {categorys.map((categorys) => (
                <div key={categorys.id} className="danh-muc-item">
                  <h5>{categorys.ten}</h5>
                </div>
              ))}
            </div>
          </div>

          <div className="col-9">
            <div className="product-list">
              {products.map((products) => (
                <div key={products.id} className="product-item">
                  <div className="block-img">
                    <img loading="lazy" src={products.url} alt={products.ten} />
                  </div>
                  <label>{products.ten}</label>
                  <p>{products.gia} VND</p>
                  {/* <button>Xem sản phẩm</button> */}
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
