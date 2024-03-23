import React from 'react';
import './Login.css';

function Login() {
  return (
    <div>
      <div className="header-w31">
        <h1>Đăng Nhập</h1>
      </div>
      <div className="main-w3layouts-agleinfo">
        <div className="wthree-form">
          <h2>Vui lòng điền vào tất cả các trường</h2>
          <form action="#" method="post">
            <div className="form-sub-w3">
              <input type="text" name="Username" placeholder="Username" required />
            </div>
            <div className="icon-w3">
              <i className="fa fa-user" aria-hidden="true"></i>
            </div>
            <div className="form-sub-w3">
              <input type="password" name="password" placeholder="Password" required />
            </div>
            <div className="icon-w3">
              <i className="fa fa-unlock-alt" aria-hidden="false"></i>
            </div>
            <label className="anim">
              <input type="checkbox" className="checkbox" />
              <span>Nhớ đăng nhập</span>
              <a href="#">Quên mật khẩu</a>
            </label>
            <div className="clear"></div>
            <div className="submit-agileits">
              <input type="submit" value="Login" />
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Login;
