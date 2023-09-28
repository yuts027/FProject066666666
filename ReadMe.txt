[v] Add EFModels
首頁html改成cshtml

=====
會員註冊/各功能(前台完成100%)-看狀態改Repo
[V]add 註冊會員功能
	add Models/Infra/HashUtility.cs
	add AppSettings,<add key="salt" value="ar!Zu@D691RR"/>
	add Models/ViewModels/RegisterVm.cs
	add RegisterExts class,擴充方法 ToMember(RegisterVM)
	add Controllers/Members/MembersController
		add Register action(Get,Post)
		add Views/Memebrs/Register.cshml(**新增demo按鈕), RegisterConfirm.cshml 
	密碼設定要求(必須包含1個特殊符號且不得少於8碼)
	
[V]	發送confirm email註冊信件
	已完成google email寄送註冊功能
	!**修改Email Helper(SendViaGoogle改成寄信)
	!**modify MembersController
		edit RegisterMember // 發送驗證信
		add GenerateConfirmationLink

[V] 實作 新會員Email確認功能 
	會員啟用的url: /Members/ActiveRegister?memberId=99&confirmCode=ttttttttttt
	modify MembersController
		add ActiveRegister(memberId, confirmCode)
	add Views/Members/ActiveRegister.cshtml

[V] 密碼新增眼睛顯示

[V] 實作 登入登出網站
	只有帳密正確而且已開通會員才允許登入，實作之前請先個別建立已/未開通的會議紀錄
	
	目前已完成登入登出功能

	modify web.config, add Authenthcation node
	add Models/ViewModels/LoginVm.cs
	modify MemberController
		add Login action(Get, Post)
		add Logout action(get, only)
	modify _layout,加入login,logout link

	Controller 加入[Authorize] 登入才能用

[V] 實作 建立會員專區/編輯會員資料
	add Models/ViewModels/EditProfileVm.cs
	add Models/ViewModels/MemberExts class, 擴充方法 ToEditProfileVm(Member)

	modify MemberController
		add Index action 會員專區頁,在登入成功之後會導向此頁
			add Views/Members/Index.cshtml(空白範本)，選單模組Views/Shared/_mod_membernav.cshtml
		修改web.config裡的defaultUrl="/Members/Index/"
		add EditProfile action(Get,Post)
			抓取編輯資料
	add MemberExts
	已成功編輯會員資料!

[V]實作變更密碼
	add Models/ViewModels/EditPasswordVm.cs
	
	modifty MemberController
		add EditPassword action(Get, Post)
		add View/Members/EditPassword.cshtml(用create template)


[V]忘記密碼/重設密碼
	add Models/ViewModels/ForgotPasswordVm.cs
	modifty MemberController
		add ForgotPassword action(Get, Post)
		add ForgotPassword view Page(create template)
		add Views/Members/ForgotPasswordConfirm.cshtml  view Page(空白範例)

		修改 Views/Members/Login.cshtml 加入"忘記密碼"連結

[V] 實作重設密碼
	add Models/ViewModels/ResetPasswordVm.cs 用來重新輸入密碼

	modifty MemberController
		add ResetPassword action(Get, Post)
		add Views/Members/ResetPassword.cshtml //重新設定密碼(create)
		add Views/Members/ConfirmResetPassword.cshtml //重新設定密碼確認

[V]大頭照修改
>已經做好傳到資料夾
>上傳待處理，原本有先完成可以上傳字串待處理呈現
可上傳更新

把自加JS寫到js資料夾


===============
Cart/Order(60%，尚未帶入使用者資料所以需要到資料庫新增)

購物流程已可以跑完，也可以新增到order資料內

SQL跑完一定要加入這筆才能運作整個購物流程!!

-- 第一筆資料 Carts
INSERT INTO dbo.Carts(MemberAccount, TotalPrice)
VALUES ('allen', 100);


目前
Rooms/Roomtype
這一頁面是預約去
只有 / A01森林區-南風苑雙人房這個可以加入購物車(尚未設定錯誤訊息)
只做出了可以加入購物車!

**預約功能待處理
[]右上購物車加減
[]錯誤訊息
[]時間查詢
[]時間判斷

**Cart功能
[]使用登入會員操作
[]上一步連結
[]錯誤訊息

訂單第二步付款方式尚未做跳出錯誤訊息(所以一定要選用)

*會員專區訂單紀錄
[]分頁功能
[]抓取正確資料

===============

Rooms(尚未完成抓取資料，但已經可以抓取到部分資料，與預約畫面相關)

==============
**新增後台**
已用精靈先新增部分畫面
*會員:70%
*訂單:尚未製作
*房型:尚未製作
*最新消息

==============
首頁
[V]抓取最新註冊前十筆會員


=============
**
會員管理(80%)
[V]會員查詢
	add MemberRepoitory 實施查詢功能
	add ViewModels/MemberVm.cs 
	add DropdownListService.cs - 下拉選單
	大頭照
	分頁功能(使用套件)

[]編輯頁面前端頁面整理

=============
[working on] 最新消息後台頁面整理
			最新消息前台整理

=============
**整體進度約完成60%

==============