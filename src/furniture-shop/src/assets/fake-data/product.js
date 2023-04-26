const product_01_image_01 = require('../images/products/product-01 (1).jpg')
const product_01_image_02 = require('../images/products/product-01 (2).jpg')

const product_02_image_01 = require('../images/products/product-02 (1).jpg')
const product_02_image_02 = require('../images/products/product-02 (2).jpg')

const product_03_image_01 = require('../images/products/product-03 (1).jpg')
const product_03_image_02 = require('../images/products/product-03 (2).jpg')

const product_04_image_01 = require('../images/products/product-04 (1).jpg')
const product_04_image_02 = require('../images/products/product-04 (2).jpg')

const product_05_image_01 = require('../images/products/product-05 (1).jpg')
const product_05_image_02 = require('../images/products/product-05 (2).jpg')

const product_06_image_01 = require('../images/products/product-06 (1).jpg')
const product_06_image_02 = require('../images/products/product-06 (2).jpg')

const product_07_image_01 = require('../images/products/product-07 (1).jpg')
const product_07_image_02 = require('../images/products/product-07 (2).jpg')

const product_08_image_01 = require('../images/products/product-08 (1).jpg')
const product_08_image_02 = require('../images/products/product-08 (2).jpg')

const product_09_image_01 = require('../images/products/product-09 (1).jpg')
const product_09_image_02 = require('../images/products/product-09 (2).jpg')

const product_10_image_01 = require('../images/products/product-10 (1).jpg')
const product_10_image_02 = require('../images/products/product-10 (2).jpg')

const product_11_image_01 = require('../images/products/product-11 (1).jpg')
const product_11_image_02 = require('../images/products/product-11 (2).jpg')

const product_12_image_01 = require('../images/products/product-12 (1).jpg')
const product_12_image_02 = require('../images/products/product-12 (2).jpg')

const products = [
    {
        title: "CELESTE - GHẾ ĂN",
        price: '189000',
        image01: product_01_image_01,
        image02: product_01_image_02,
        categorySlug: "ghe",
        colors: ["grey", "red", "orange"],
        slug: "ghe-an-1",
        size: ["s", "m", "l", "xl"],
        description: "Ghế ăn celeste cao cấp"
    },
    {
        title: "MIALCA - BÀN ĂN",
        price: '159000',
        image01: product_02_image_01,
        image02: product_02_image_02,
        categorySlug: "ban",
        colors: ["white", "red", "blue"],
        slug: "ban-an-2",
        size: ["s", "m"],
        description: "Bàn ăn Mialca cao cấp"
    },
    {
        title: "DALES - GIƯỜNG",
        price: '190000',
        image01: product_03_image_01,
        image02: product_03_image_02,
        categorySlug: "giuong",
        colors: ["white", "red", "orange", "yellow"],
        slug: "giuong-dales-3",
        size: ["m"],
        description: "Giường Dales cao cấp"
    },
    {
        title: "WORKY - BÀN LÀM VIỆC",
        price: '194000',
        image01: product_04_image_01,
        image02: product_04_image_02,
        categorySlug: "ban",
        colors: ["white", "orange", "blue"],
        slug: "ban-lam-viec-4",
        size: ["xl"],
        description: "Bàn làm việc Worky cao cấp"
    },
    {
        title: "CONTEMPO - TỦ TV",
        price: '194000',
        image01: product_05_image_01,
        image02: product_05_image_02,
        categorySlug: "tu",
        colors: ["white", "pink"],
        slug: "tu-tv-5",
        size: ["xxl"],
        description: "tủ tivi contempo"
    },
    {
        title: "CARAMBOLA - BÀN COFFEE",
        price: '194000',
        image01: product_06_image_01,
        image02: product_06_image_02,
        categorySlug: "ban",
        colors: ["black"],
        slug: "ban-coffee-6",
        size: ["s", "m", "xl"],
        description: "Bàn cà phê carambola"
    },
    {
        title: "BERKSHIRE - GIƯỜNG",
        price: '24900000',
        image01: product_07_image_01,
        image02: product_07_image_02,
        categorySlug: "giuong",
        colors: ["white", "red", "orange", "blue"],
        slug: "giuong-7",
        size: ["l", "xl"],
        description: "Giường Berkshire cao cấp"
    },
    {
        title: "GION - BÀN CONSOLE",
        price: '194000',
        image01: product_08_image_01,
        image02: product_08_image_02,
        categorySlug: "ban",
        colors: ["white", "red", "black"],
        slug: "ban-console-8",
        size: ["s", "m", "xl"],
        description: "Bàn console Gion cao cấp"
    },
    {
        title: "KAURO - GHẾ ĂN",
        price: '194000',
        image01: product_09_image_01,
        image02: product_09_image_02,
        categorySlug: "ghe",
        colors: ["white", "blue"],
        slug: "ghe-an-9",
        size: ["m"],
        description: "Ghế ăn Kauro cao cấp"
    },
    {
        title: "LAKIN - GHẾ BĂNG",
        price: '194000',
        image01: product_10_image_01,
        image02: product_10_image_02,
        categorySlug: "ghe",
        colors: ["blue", "black"],
        slug: "ghe-bang-10",
        size: ["l"],
        description: "Ghế băng lakin cao cấp"
    },
    {
        title: "DALBERGIA - BÀN COFFEE",
        price: '194000',
        image01: product_11_image_01,
        image02: product_11_image_02,
        categorySlug: "ban",
        colors: ["blue", "black"],
        slug: "ban-coffee-11",
        size: ["s", "m", "xl"],
        description: "Bàn cà phê dalbergia cao cấp"
    },
    {
        title: "ROMIW - GHẾ BÀNH",
        price: '194000',
        image01: product_12_image_01,
        image02: product_12_image_02,
        categorySlug: "ghe",
        colors: ["white"],
        slug: "ghe-banh-12",
        size: ["s", "m", "xl"],
        description: "Ghế bành Romiw cao cấp"
    },
]

const getAllProducts = () => products

const getProducts = (count) => {
    const max = products.length - count
    const min = 0
    const start = Math.floor(Math.random() * (max - min) + min)
    return products.slice(start, start + count)
}

const getProductBySlug = (slug) => products.find((e) => e._slug === (slug))

const productData = {
    getAllProducts,
    getProducts,
    getProductBySlug
}

export default productData