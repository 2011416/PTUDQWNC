import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { useLocation } from 'react-router-dom';

import Helmet from '../components/Helmet'
import HeroSlider from '../components/HeroSlider'
import Section, { SectionTitle, SectionBody } from '../components/Section'
import PolicyCard from '../components/PolicyCard'
import Grid from '../components/Grid'
import ProductCard from '../components/ProductCard'

import heroSliderData from '../assets/fake-data/hero-slider'
import policy from '../assets/fake-data/policy'
import productData from '../assets/fake-data/product'

import banner from "../assets/images/banner.png"
import { getProducts, getProductFilter } from '../Services/Repository'

const Home = () => {
  const [productsList, setProductsList] = useState([]);
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  let k = "", p = 1, ps = 10;


  useEffect(() => {
    document.title = "Danh sách sản phẩm";
    getProducts(k,ps, p).then((data)  => { 
      if (data) 
        setProductsList(data.items);
      else setProductsList([]);
        setIsVisibleLoading(false);
    });

  }, [k, ps,p]);

  useEffect(() => {
    window.scrollTo(0, 0);
}, [productsList]);


    if (productsList.length > 0)
    return (
        <div className='p-4'>
            {productsList.map((item, index) => {
                return (
                    <Helmet title="Trang chủ">
          {/* hero slider */}
          <HeroSlider 
              data={heroSliderData}
              control={true}
              auto={false}
              timeOut={5000}
          />
          {/* end hero slider */}

          {/* policy section */}
             <Section>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            policy.map((item, index) => <Link key={index} to="/policy">
                                <PolicyCard
                                    name={item.name}
                                    description={item.description}
                                    icon={item.icon}
                                />
                            </Link>)
                        }
                    </Grid>
                </SectionBody>
            </Section>
          {/* end policy section */}

          {/* best selling section */}
          <Section>
                <SectionTitle>
                    top sản phẩm bán chạy trong tuần
                </SectionTitle>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            productsList.map((item, index) => (
                                <ProductCard
                                    key={index}
                                    img01={item.urlImage}
                                    img02={item.urlImage}
                                    name={item.name}
                                    price={Number(item.price)}
                                    slug={item.urlSlug}
                                />
                            ))
                        }
                    </Grid>
                </SectionBody>
            </Section>
            {/* end best selling section */}

             {/* new arrival section */}
             <Section>
                <SectionTitle>
                    sản phẩm mới
                </SectionTitle>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            productsList.map((item, index) => (
                                <ProductCard
                                    key={index}
                                    img01={item.urlImage}
                                    img02={item.urlImage}
                                    name={item.name}
                                    price={Number(item.price)}
                                    slug={item.urlSlug}
                                />
                            ))
                        }
                    </Grid>
                </SectionBody>
            </Section>
            {/* end new arrival section */}

              {/* banner */}
              <Section>
                <SectionBody>
                    <Link to="/catalog">
                        <img src={banner} alt="" />
                    </Link>
                </SectionBody>
            </Section>
            {/* end banner */}

             {/* popular product section */}
             <Section>
                <SectionTitle>
                    phổ biến
                </SectionTitle>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                             productsList.map((item, index) => (
                                <ProductCard
                                    key={index}
                                    img01={item.urlImage}
                                    img02={item.urlImage}
                                    name={item.name}
                                    price={Number(item.price)}
                                    slug={item.urlSlug}
                                />
                            ))
                        }
                    </Grid>
                </SectionBody>
            </Section>
            {/* end popular product section */}

    </Helmet>
                );
            })}
        </div>
    );
    else return (

    <Helmet title="Trang chủ">
          {/* hero slider */}
          <HeroSlider 
              data={heroSliderData}
              control={true}
              auto={false}
              timeOut={5000}
          />
          {/* end hero slider */}

          {/* policy section */}
             <Section>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            policy.map((item, index) => <Link key={index} to="/policy">
                                <PolicyCard
                                    name={item.name}
                                    description={item.description}
                                    icon={item.icon}
                                />
                            </Link>)
                        }
                    </Grid>
                </SectionBody>
            </Section>
          {/* end policy section */}

          {/* best selling section */}
          <Section>
                <SectionTitle>
                    top sản phẩm bán chạy trong tuần
                </SectionTitle>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            productData.getProducts(4).map((item, index) => (
                                <ProductCard
                                    key={index}
                                    img01={item.image01}
                                    img02={item.image02}
                                    name={item.title}
                                    price={Number(item.price)}
                                    slug={item.slug}
                                />
                            ))
                        }
                    </Grid>
                </SectionBody>
            </Section>
            {/* end best selling section */}

             {/* new arrival section */}
             <Section>
                <SectionTitle>
                    sản phẩm mới
                </SectionTitle>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            productData.getProducts(8).map((item, index) => (
                                <ProductCard
                                    key={index}
                                    img01={item.image01}
                                    img02={item.image02}
                                    name={item.title}
                                    price={Number(item.price)}
                                    slug={item.slug}
                                />
                            ))
                        }
                    </Grid>
                </SectionBody>
            </Section>
            {/* end new arrival section */}

              {/* banner */}
              <Section>
                <SectionBody>
                    <Link to="/catalog">
                        <img src={banner} alt="" />
                    </Link>
                </SectionBody>
            </Section>
            {/* end banner */}

             {/* popular product section */}
             <Section>
                <SectionTitle>
                    phổ biến
                </SectionTitle>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            productData.getProducts(12).map((item, index) => (
                                <ProductCard
                                    key={index}
                                    img01={item.image01}
                                    img02={item.image02}
                                    name={item.title}
                                    price={Number(item.price)}
                                    slug={item.slug}
                                />
                            ))
                        }
                    </Grid>
                </SectionBody>
            </Section>
            {/* end popular product section */}

    </Helmet>
  );

}

export default Home