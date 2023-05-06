import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import Helmet from "../components/Helmet";
import Section, { SectionBody, SectionTitle } from "../components/Section";
import Grid from "../components/Grid";
import ProductCard from "../components/ProductCard";
import ProductView from "../components/ProductView";

import productData from "../assets/fake-data/product";
import { getProductBySlug, getProducts } from "../Services/Repository";

function ViewProduct() {
  const { slug } = useParams();

  const product = productData.getProductBySlug(slug);

  const relatedProducts = productData.getProducts(8);

  const [productsList, setProductsList] = useState([]);
  let k = "",
    p = 1,
    ps = 10;

  React.useEffect(() => {
    window.scrollTo(0, 0);
  }, [product]);

  useEffect(() => {
    document.title = "Danh sách sản phẩm";
    getProducts(k, ps, p).then((data) => {
      if (data) setProductsList(data.items);
      else setProductsList([]);
    });
  }, [k, ps, p]);

  if (productsList.length > 0)
    return (
        <div className="p-4">
        {productsList.map((item, index) => {
          return (
            <Helmet title={item.name}>
              <Section>
                <SectionBody>
                  <ProductView productsList={product} />
                </SectionBody>
              </Section>
              <Section>
                <SectionTitle>Khám phá thêm</SectionTitle>
                <SectionBody>
                  <Grid col={4} mdCol={2} smCol={1} gap={20}>
                    {relatedProducts.map((item, index) => (
                      <ProductCard
                        key={index}
                        img01={item.image01}
                        img02={item.image02}
                        name={item.title}
                        price={Number(item.price)}
                        slug={item.slug}
                      />
                    ))}
                  </Grid>
                </SectionBody>
              </Section>
            </Helmet>
          );
        })}
        </div>
    );


    else return (
        <Helmet title={product.title}>
        <Section>
          <SectionBody>
            <ProductView product={product} />
          </SectionBody>
        </Section>
        <Section>
          <SectionTitle>Khám phá thêm</SectionTitle>
          <SectionBody>
            <Grid col={4} mdCol={2} smCol={1} gap={20}>
              {relatedProducts.map((item, index) => (
                <ProductCard
                  key={index}
                  img01={item.image01}
                  img02={item.image02}
                  name={item.title}
                  price={Number(item.price)}
                  slug={item.slug}
                />
              ))}
            </Grid>
          </SectionBody>
        </Section>
      </Helmet>
    );

}

export default ViewProduct;


