import React from 'react';
import Helmet from '../components/Helmet';
import { Link } from 'react-router-dom';
import banner from "../assets/images/banner.png"
import policy from '../assets/fake-data/policy';
import PolicyCard from '../components/PolicyCard';
import Grid from '../components/Grid';
import Section, { SectionTitle, SectionBody } from '../components/Section'

const About = () => {
  return (
    <Helmet title="Giới thiệu">
    <div className="about-page">
      <h1>About Us</h1>
       <h1>...............................................</h1>
       <h1>LỊCH SỬ HÌNH THÀNH</h1>
      <p>Ra đời từ ý tưởng tạo nên sự khác biệt, FurnitureShop đã giữ vững và phát triển trở thành vị trí hàng đầu trong thị trường nội thất Việt Nam.</p>
      <p>Đến nay, FurnitureShop đã có nhiều cửa hàng quy mô và chuyên nghiệp tại các thành phố lớn là Hà Nội và TP.HCM, Bình Dương.</p>
             <h1>...............................................</h1>
       <h1>Giá trị và sự khác biệt</h1>
      <p>Với mong muốn phát triển thương hiệu Việt bằng nội lực, FurnitureShop đã chú trọng vào thiết kế và sản xuất nội thất trong nước. Danh mục sản phẩm của FurnitureShop thường xuyên được đổi mới và cập nhật, liên tục cung cấp cho khách hàng các dòng sản phẩm theo xu hướng mới nhất. Do chính người Việt thiết kế và sản xuất, nội thất thương hiệu FurnitureShop luôn phù hợp với cuộc sống Á Đông, đem đến sự tiện nghi hoàn hảo trong mọi không gian sống.</p>
      <h1>...............................................</h1>
       <h1>Chất lượng và dịch vụ</h1>
      <p>Chất lượng của nguyên vật liệu, phụ kiện và quy trình sản xuất đều được kiểm định và giám sát chặt chẽ bởi hệ thống quản lý chất lượng ISO 9001. Sản phẩm của FurnitureShop được thiết kế theo định hướng công năng sử dụng, thẩm mỹ và chất lượng. Trong những năm gần đây, thương hiệu luôn hướng đến xu hướng thiết kế xanh nhằm đóng góp không chỉ một không gian sống tiện nghi mà còn là một môi trường sống trong lành cho người sử dụng và cộng đồng.</p>
    </div>

    <Link to="/catalog">
        <img src={banner} alt="" />
    </Link>

    <h1>.......................................................................................................................................................................</h1>

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
    
    </Helmet>
  );
};

export default About;