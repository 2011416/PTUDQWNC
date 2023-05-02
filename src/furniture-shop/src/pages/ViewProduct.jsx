import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';

import Helmet from '../components/Helmet'
import Section, {SectionBody, SectionTitle} from '../components/Section'
import Grid from '../components/Grid'
import ProductCard from '../components/ProductCard'
import ProductView from '../components/ProductView'

import productData from '../assets/fake-data/product'
import { getProducts, getProductFilter } from '../Services/Repository'

function ViewProduct(){

    const [productsList, setProductsList] = useState([]);
    const [isVisibleLoading, setIsVisibleLoading] = useState(true);
    let k = "", p = 1, ps = 3;

    const {slug} =useParams();

    const product = productData.getProductBySlug(slug);

    const relatedProducts = productData.getProducts(8)

    React.useEffect(() => {
        window.scrollTo(0,0)
    }, [product])

    if (productsList.length > 0)
    return (
        <Helmet title={product.title}>
            <Section>
                <SectionBody>
                    <ProductView product={product}/>
                </SectionBody>
            </Section>
            <Section>
                <SectionTitle>
                    Khám phá thêm
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
        </Helmet>
    );
    else return 
    (
        <Helmet title={product.title}>
        <Section>
            <SectionBody>
                <ProductView product={product}/>
            </SectionBody>
        </Section>
        <Section>
            <SectionTitle>
                Khám phá thêm
            </SectionTitle>
            <SectionBody>
                <Grid
                    col={4}
                    mdCol={2}
                    smCol={1}
                    gap={20}
                >
                    {
                        relatedProducts.map((item, index) => (
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
    </Helmet>
    )
}

export default ViewProduct