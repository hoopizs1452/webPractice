<!DOCTYPE html>
<html lang="zh_tw"><head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
  <meta name="format-detection" content="telephone=no">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>PChome 線上購物</title>
  <link rel="apple-touch-icon" type="image/x-icon" href="https://e.ecimg.tw/img/icon/24-64x64.ico" sizes="64x64">
  <link rel="icon" type="image/x-icon" href="https://e.ecimg.tw/img/icon/24-64x64.ico" sizes="64x64">
  <link rel="icon" type="image/x-icon" href="https://e.ecimg.tw/img/icon/24-32x32.ico" sizes="32x32">
  <link rel="icon" type="image/x-icon" href="https://e.ecimg.tw/img/icon/24-16x16.ico" sizes="16x16">
  <link type="text/css" href="pchome.css" rel="stylesheet">
  <script type="text/javascript" async="" src="PChome_files/analytics.js"></script><script type="text/javascript" async="" src="PChome_files/js.js"></script><script type="text/javascript" async="" src="PChome_files/recaptcha__zh_tw.js" crossorigin="anonymous" integrity="sha384-OQ610rKYc5kPAis2Jd0dd5p6w/bfJ7vmqtiFlWRVuLoCGDaQcwJnwdf0ze1hh6Qc"></script><script async="" src="PChome_files/gtm.js"></script><script type="text/javascript" src="PChome_files/a"></script>
  <script type="text/javascript" src="PChome_files/api.js"></script>
</head>
<body>
    <div id="WRAPPER" class="ecsite-layout style_shopping ecsite-login">
        <!-- HEADER start -->
        <div id="HEADER">
            <div class="block_H s_desktop">
                <h1 class="logotype"><a href="https://shopping.pchome.com.tw/">PChome 線上購物</a></h1>
            </div>
            <div class="block_H s_mobile">
                <a id="btnBack" class="back" href="javascript:void(0)"><span class="ico">返回</span></a>
                <h1 class="logotype"><a class="ico" href="https://24h.m.pchome.com.tw/">PChome 24h購物</a></h1>
            </div>
        </div>
        <!-- HEADER end -->
        <!-- CONTENT start -->
        <div id="CONTENT" class="layout-wrapper">
            <div class="layout-center">
                <!-- block_C start -->
                <div class="block_C">
                    <dl class="login_form">
                        <dd class="header">
                            <p class="remind unblock">如同意與「財政部電子發票整合服務平台」進行歸戶，<br>請登入PChome線上購物，以進行歸戶認證作業。</p>
                            <ul class="tabs">
                                <li class="actived"><span tabindex="1">會員登入</span></li>
                                <li><span tabindex="1">立即註冊</span></li>
                            </ul>
                        </dd>
                        <dd class="content body">
                            <dl class="login_box">
                                <form action="service.php" method="POST">
                                    <dd>
                                        <input id="loginAcc" name="loginAcc" class="text" type="text" placeholder="請輸入手機號碼 或 Email" tabindex="2" autocapitalize="none" autocomplete="off" maxlength="200" value="">
                                        <ul class="list_box"></ul>
                                    </dd>
                                    <dd>
                                        <input id="loginPwd" name="loginPwd" type="password" class="text" placeholder="請輸入密碼 ( 英文大小寫有差別 )" tabindex="3" maxlength="200" value="">
                                        <ul class="list_box"></ul>
                                    </dd>
                                    <dd>
                                        <ul class="setting">
                                            <li><label><input id="btnRemember" type="checkbox" checked="checked" tabindex="4" value=""><span class="note">記住帳號</span></label></li>
                                            <li><a id="resetPasswordLink" class="alink" href="javascript:void(0)" tabindex="5">忘記密碼</a></li>
                                        </ul>
                                    </dd>
                                    <dd>
                                        <button class="ui-btn btnSubmit b-submit test" type="submit" oncllick="myFunc()">登入</button>
                                        <ul class="list_box"></ul>
        
                                        <ul class="list_box foot unblock"></ul>
                                    </dd>
                                </form>
                                <dd>
                                    <dl class="platform_box">
                                        <dt><span>快速登入</span></dt>
                                        <dd>
                                            <ul class="col-1">
                                                <li><a class="site google s_single" href="javascript:void(0)" platformid="google"><span>Sign in with Google</span></a></li>
                                                <li><a class="site apple s_single" href="javascript:void(0)" platformid="apple"><span>Sign in with Apple</span></a></li>
                                            </ul>
                                            <ul class="col-4">
                                                <li><a class="site xpmember ruten" href="javascript:void(0)" platformid="PRT"><span>露天拍賣</span></a></li>
                                                <li><a class="site xpmember pchome" href="javascript:void(0)" platformid="PPT"><span>PChome Online</span></a></li>
                                                <li><a class="site xpmember pchomepay" href="javascript:void(0)" platformid="PAY"><span>支付連</span></a></li>
                                                <li><a class="site xpmember pcstore" href="javascript:void(0)" platformid="PST"><span>商店街</span></a></li>
                                                <li><a class="site xpmember seller" href="javascript:void(0)" platformid="PSL"><span>個人賣場</span></a></li>
                                                <li><a class="site xpmember pi" href="javascript:void(0)" platformid="PPI"><span>Pi&nbsp;拍錢包</span></a></li>
                                                <li><a class="site xpmember travel" href="javascript:void(0)" platformid="PTV"><span>PChome 旅遊</span></a></li>
                                                <li><a class="site xpmember thai" href="javascript:void(0)" platformid="PTH"><span>PChome Thai</span></a></li>
                                            </ul>
                                        </dd>
                                    </dl>
                                </dd>
                            </dl>
                        </dd>
                        <dd class="footer body">
                            <div class="board info">PChome&nbsp;不會以任何理由要求您轉帳匯款，嚴防詐騙</div>
                        </dd>

                        <dd class="content body unblock" data-type="phone">
                            <dl class="login_box">
                                <dd>
                                    <input class="text signupAccount" type="text" placeholder="請輸入手機號碼" tabindex="2" autocapitalize="none" autocomplete="off" maxlength="200">
                                    <ul class="list_box"></ul>
                                </dd>
                                <dd>
                                    <input type="password" class="text signupPassword" placeholder="請輸入密碼 ( 英文大小寫有差別 )" tabindex="3" maxlength="200" value="">
                                    <ul class="list_box"></ul>
                                </dd>
                                <dd>
                                    <input type="password" class="text signupPassword_C" placeholder="請再輸入一次密碼" tabindex="4" maxlength="200" value="">
                                    <ul class="list_box"></ul>
                                </dd>
                                <dd>
                                    <a id="btnPhoneSignup" class="ui-btn btnSubmit b-submit" href="javascript:void(0)">註冊</a>
                                    <ul class="list_box"></ul>
                                    <ul class="list_box">
                                        <li>點擊註冊代表您同意&nbsp;PChome&nbsp;之&nbsp;<a class="alink signupservice" href="javascript:void(0)">會員條款</a>&nbsp;與&nbsp;<a class="alink signupprivacy" href="javascript:void(0)">客戶隱私權條款</a></li>
                                    </ul>

                                </dd>
                            </dl>
                        </dd>
                        <dd class="footer body unblock">
                            <div class="board info">PChome&nbsp;不會以任何理由要求您轉帳匯款，嚴防詐騙</div>
                            <div class="board note">沒有手機號碼？<a class="alink linkbutton changeSignup" href="javascript:void(0)">改用&nbsp;Email&nbsp;註冊</a></div>

                        </dd>

                        <dd class="content unblock" data-type="email">
                            <dl class="login_box">
                                <dd>
                                    <input class="text signupAccount" type="text" placeholder="請輸入 Email" tabindex="2" autocapitalize="none" autocomplete="off" maxlength="200">
                                    <ul class="list_box"></ul>
                                </dd>
                                <dd>
                                    <input type="password" class="text signupPassword" placeholder="請輸入密碼 ( 英文大小寫有差別 )" tabindex="3" maxlength="200" value="">
                                    <ul class="list_box"></ul>
                                </dd>
                                <dd>
                                    <input type="password" class="text signupPassword_C" placeholder="請再輸入一次密碼" tabindex="4" maxlength="200" value="">
                                    <ul class="list_box"></ul>
                                </dd>
                                <dd>
                                    <a id="btnEmailSignup" class="ui-btn btnSubmit b-submit" href="javascript:void(0)">註冊</a>
                                    <ul class="list_box"></ul>
                                    <ul class="list_box">
                                        <li>點擊註冊代表您同意&nbsp;PChome&nbsp;之&nbsp;<a class="alink signupservice" href="javascript:void(0)">會員條款</a>&nbsp;與&nbsp;<a class="alink signupprivacy" href="javascript:void(0)">客戶隱私權條款</a></li>
                                    </ul>
                                </dd>
                            </dl>
                        </dd>
                        <dd class="footer unblock">
                            <div class="board info">PChome&nbsp;不會以任何理由要求您轉帳匯款，嚴防詐騙</div>
                            <div class="board note">沒有Email？<a class="alink linkbutton changeSignup" href="javascript:void(0)">改用手機號碼註冊</a></div>
                        </dd>
                    </dl>
                </div>
                <!-- block_C end -->
            </div>
        </div>
        <!-- CONTENT end -->
        <!-- FOOTER start -->
        <div id="FOOTER"><!-- FOOTER start -->
<div id="FOOTER">
	<div class="ecsite-footer s_desktop">
		<dl class="msg_box">
			<dd>
				<ul>
					<li><a href="http://shopping.pchome.com.tw/">PChome線上購物</a></li>
					<li>網路家庭國際資訊股份有限公司</li>
					<li>版權所有</li>
					<li>轉載必究</li>
					<li><a href="https://ecvip.pchome.com.tw/web/pages/contactinfo.htm">聯絡我們</a></li>
					<li><a href="https://ecvip.pchome.com.tw/web/pages/privacy.htm">隱私權聲明</a></li>
					<li><a href="https://ecssl.pchome.com.tw/sys/cflowex/index/staticPage/CLAUSE">服務條款</a></li>
					<li><a class="anchor" href="https://shopping.pchome.com.tw/sitemap" accesskey="M" title="網站導覽">:::</a></li>
				</ul>
			</dd>
			<dd>
				<ul>
					<li>106</li>
					<li>台北市大安區敦化南路二段105號15樓</li>
					<li>電話(不含例假日)：02-2326-1460</li>
					<li><span class="s_parenthesis">本公司不會以此電話號碼撥打給您，如有來電顯示此號碼，請勿理會</span></li>
				</ul>
			</dd>
			<dd>PChome and PChome Online are trademarks of PChome Online Inc.</dd>
			<dd>本網站產品已投保富邦產物產品責任保險$250,000,000元。<span class="s_parenthesis">保險證號：0525字第20AML0002838號</span></dd>
			<dd><ul>
        <li>本網站採用 reCAPTCHA 保護機制</li>
        <li><a href="https://policies.google.com/privacy">隱私權</a></li>
        <li><a href="https://policies.google.com/terms">條款</a></li>
      </ul></dd>
			<!-- RWD版於電腦尺寸顯示時，無.bar_version區塊 -->
		</dl>
	</div>
	<div class="ecsite-footer s_mobile">
		<dl class="msg_box">
			<dd>
				<ul>
					<li>網路家庭國際資訊股份有限公司</li>
					<li>版權所有</li>
					<li>轉載必究</li>
				</ul>
			</dd>
			<dd>
				<ul>
					<li><a href="http://faq.pchome.com.tw/faq_solution.html?q_id=16&amp;c_nickname=member&amp;f_id=4">隱私權聲明</a></li>
					<li><a href="https://ecssl.pchome.com.tw/sys/cflowex/index/staticPage/CLAUSE">服務條款</a></li>
					<li><a href="https://ecvip.pchome.com.tw/contact/">聯絡我們</a></li>
				</ul>
			</dd>
		</dl>
	</div>
</div>
<!-- FOOTER end --></div>
        <!-- FOOTER end -->
    </div>
    <div id="origshadow" class="overlay-shadow fade-ready"></div>
    <div class="overlay-lightbox modal-pure fade-ready">
        <div class="msg_box"></div>
        <ul class="bar_tool">
            <li><span class="ui-btn">確定</span></li>
        </ul>
    </div>
    <div id="signupphoneverify" class="overlay-lightbox modal-layout s_confirm fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3>手機號碼驗證</h3>
                <span class="ui-btn b-close">關閉</span>
            </div>
            <div class="lightbox-content">
                <div class="msg_box">
                    <div class="head">您的手機號碼尚未進行驗證，我們已透過簡訊將驗證碼傳送至您的手機，驗證成功後即可成為PChome線上購物會員。
                    <strong class="user-contact"></strong>
                    </div>
                    <div class="body">
                        <dl class="verification_box">
                            <dt>請輸入正確的驗證碼</dt>
                            <dd>
                                <input type="text" class="text OTPCaptcha"><span class="alink resendOTPCaptcha">重新傳送</span>
                                <ul class="list_box"></ul>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
            <div class="lightbox-footer">
                <ul class="bar_tool">
                    <li><span id="phoneOtpSubmit" class="ui-btn btnSubmit">繼續</span></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="signupemailverify" class="overlay-lightbox modal-layout s_confirm fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3>Email驗證</h3>
                <span class="ui-btn b-close">關閉</span>
            </div>
            <div class="lightbox-content">
                <div class="msg_box">
                    <div class="head">您的Email尚未進行驗證，我們已將驗證碼傳送至您的Email信箱，驗證成功後即可成為PChome線上購物會員。
                    <strong class="user-contact"></strong>
                    </div>
                    <div class="body">
                        <dl class="verification_box">
                            <dt>請輸入正確的驗證碼</dt>
                            <dd>
                                <input type="text" class="text OTPCaptcha"><span class="alink resendOTPCaptcha">重新傳送</span>
                                <ul class="list_box"></ul>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
            <div class="lightbox-footer">
                <ul class="bar_tool">
                    <li><span id="emailOtpSubmit" class="ui-btn btnSubmit">繼續</span></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="realnameverify" class="overlay-lightbox modal-layout s_confirm fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3>會員條款 與 客戶隱私權條款</h3>
                <span class="ui-btn b-close">關閉</span>
            </div>
            <div class="lightbox-content">
                <div class="msg_box">
                    <div class="head">
                        <ul class="email_box">
                            <li class="title">親愛的顧客您好：</li>
                            <li class="info">PChome線上購物為傾聽顧客的需求，提供更完善且貼心的服務，請同意會員條款。感謝您的支持！</li>
                        </ul>
                        <div class="service-privacy-terms">
                            <input id="realnameAgreeterms" type="checkbox" checked="checked"><label>我同意PChome之<a class="alink realnameservice" href="javascript:void(0)">會員條款</a>與<a class="alink realnameprivacy" href="javascript:void(0)">客戶隱私權條款</a></label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="lightbox-footer">
                <ul class="bar_tool">
                    <li><span id="realnameSubmit" class="ui-btn btnSubmit">繼續</span></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="realnameemailverify" class="overlay-lightbox modal-layout s_confirm fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3>Email驗證 與 條款</h3>
                <span class="ui-btn b-close">關閉</span>
            </div>
            <div class="lightbox-content">
                <div class="msg_box">
                    <div class="head emailCaptcha">您的Email&nbsp;尚未進行驗證，我們已將驗證碼傳送至您的Email&nbsp;信箱：
                    <strong class="user-contact"></strong>
                    </div>
                    <div class="body">
                        <dl class="verification_box emailCaptcha">
                            <dt>請輸入正確的驗證碼</dt>
                            <dd>
                                <input id="emailRealnameCaptcha" type="text" class="text OTPCaptcha"><span id="resendRealnameCaptcha" class="alink">重新傳送</span>
                                <ul class="list_box"></ul>
                            </dd>
                        </dl>
                        <div class="service-privacy-terms emailAgreeterms">
                            <input id="emailAgreeterms" type="checkbox" checked="checked"><label>我同意PChome之<a class="alink realnameservice" href="javascript:void(0)">會員條款</a>與<a class="alink realnameprivacy" href="javascript:void(0)">客戶隱私權條款</a></label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="lightbox-footer">
                <ul class="bar_tool">
                    <li><span id="realnameEmailSubmit" class="ui-btn btnSubmit">繼續</span></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="signupterms" class="overlay-lightbox modal-layout s_confirm fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3>會員條款 與 客戶隱私權條款</h3>
                <span class="ui-btn b-close">關閉</span>
            </div>
            <div class="lightbox-content">
                <div class="msg_box">
                    <div class="head">
                        <ul class="email_box">
                            <li class="title">親愛的顧客您好：</li>
                            <li class="info">PChome線上購物為傾聽顧客的需求，提供更完善且貼心的服務，將進行會員認證。感謝您的支持！</li>
                        </ul>
                        <div class="service-privacy-terms"></div>
                    </div>
                </div>
            </div>
            <div class="lightbox-footer">
                <ul class="bar_tool">
                    <li><span class="ui-btn">繼續</span></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="boardbox" class="overlay-lightbox modal-layout s_info fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3></h3>
                <a class="ui-btn b-close" href="javascript:void(0);">關閉</a>
            </div>
            <div class="lightbox-content">
                <div class="msg_box"></div>
            </div>
            <div class="lightbox-footer">
            </div>
        </div>
    </div>
    <div id="portalmsg" class="overlay-lightbox modal-layout s_confirm fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3>PChome信箱服務停止相關公告</h3>
                <span class="ui-btn b-close">關閉</span>
            </div>
            <div class="lightbox-content">
                <div class="msg_box">
                    <div class="head">親愛的顧客您好：</div>
                    <div class="portal_box">
                        <p>因應PChome信箱將於2020/9/30停止服務，您將無法繼續收到PChome線上購物相關通知信件，為確保您的購物權益，請確認是否完成下面兩個動作：</p>
                        <ol>
                            <li>手機帳號認證，方便快速登入以及忘記密碼免擔心</li>
                            <li>下載PChome24h購物 APP，接收相關推播通知</li>
                        </ol>
                        <p>我們將於今年底前完成備用信箱相關功能，並於網站及APP公告，以提供您更全面的服務。</p>
                        <p>感謝您一直以來對PChome的支持愛護，讓PChome 20年陪伴您的生活及成長，期待您下載PChome24h購物APP或進行手機認證，體驗更方便、優質的服務。</p>
                    </div>
                </div>
            </div>
            <div class="lightbox-footer">
                <ul class="bar_tool">
                    <li><a href="https://ecvip.pchome.com.tw/web/membercenter/account" class="ui-btn">認證手機</a></li>
                    <li><a href="http://24h.m.pchome.com.tw/appget.php" class="ui-btn appget">下載APP</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="quitdbbox" class="overlay-lightbox modal-layout s_info fade-ready">
        <div class="lightbox-wrapper">
            <div class="lightbox-header">
                <h3></h3>
                <a class="ui-btn b-close" href="javascript:void(0);">關閉</a>
            </div>
            <div class="lightbox-content">
                <div class="msg_box">
                    <div class="portal_box"><p></p></div>
                </div>
            </div>
            <div class="lightbox-footer"></div>
        </div>
    </div>
    <form id="post_form" action="" method="post"></form>

<div><div class="grecaptcha-badge" data-style="bottomright" style="width: 256px; height: 60px; display: block; transition: right 0.3s ease 0s; position: fixed; bottom: 14px; right: -186px; box-shadow: gray 0px 0px 5px; border-radius: 2px; overflow: hidden;"><div class="grecaptcha-logo"><iframe title="reCAPTCHA" src="PChome_files/anchor.html" role="presentation" name="a-nr81mrl7322h" scrolling="no" sandbox="allow-forms allow-popups allow-same-origin allow-scripts allow-top-navigation allow-modals allow-popups-to-escape-sandbox allow-storage-access-by-user-activation" width="256" height="60" frameborder="0"></iframe></div><div class="grecaptcha-error"></div><textarea id="g-recaptcha-response-100000" name="g-recaptcha-response" class="g-recaptcha-response" style="width: 250px; height: 40px; border: 1px solid rgb(193, 193, 193); margin: 10px 25px; padding: 0px; resize: none; display: none;"></textarea></div><iframe style="display: none;"></iframe></div><script type="text/javascript" id="">function getCookieAtGTM(b){b+="\x3d";var c=decodeURIComponent(document.cookie);c=c.split(";");for(var d=0;d<c.length;d++){for(var a=c[d];" "==a.charAt(0);)a=a.substring(1);if(0==a.indexOf(b))return a.substring(b.length,a.length)}return""}
function myFunc(){alert("How are you?");}
try{var objDate=new Date;objDate.setTime(objDate.getTime()+18E5);if(0<=["shopping.pchome.com.tw","24h.pchome.com.tw","24h.m.pchome.com.tw","mall.pchome.com.tw"].indexOf(window.location.host)){var strSite="24h";"/kdn/"==window.location.pathname.substr(0,5)?strSite="japan":"/prod/"!=window.location.pathname.substr(0,6)||isNaN(window.location.pathname.substr(6,16))?"shopping.pchome.com.tw"==window.location.host?strSite="shopping":"mall.pchome.com.tw"==window.location.host?strSite="mall":"24h.pchome.com.tw"==
window.location.host?strSite="24h":"24h.m.pchome.com.tw"==window.location.host&&(strSite="24h"):strSite="japan";document.cookie="gsite\x3d"+strSite+";expires\x3d"+objDate.toGMTString()+";domain\x3d.pchome.com.tw;path\x3d/"}else strSite=getCookieAtGTM("gsite")?getCookieAtGTM("gsite"):"24h",document.cookie="gsite\x3d"+strExistSite+";expires\x3d"+objDate.toGMTString()+";domain\x3d.pchome.com.tw;path\x3d/"}catch(b){};</script></body></html>
