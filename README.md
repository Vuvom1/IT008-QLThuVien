<div id="Top"></div>

# QUẢN LÝ THƯ VIỆN
Hỗ trợ các thư viện dễ dàng hơn trong quản lý sách và giúp người mượn mua sách thuận lợi hơn.

## Mục lục

 [I. Mở đầu](#Modau)

 [II. Mô tả](#Mota)

> [1. Ý tưởng](#Ytuong)
>
> [2. Công nghệ](#Congnghe)
>
> [3. Người dùng](#Doituongsudung)
>
> [4. Mục tiêu](#Muctieu)
>
> [5. Tính năng](#Tinhnang)

[III. Tác giả](#Tacgia)

[IV. Người hướng dẫn](#Nguoihuongdan)

[V. Tổng kết](#Tongket)


<!-- MỞ ĐẦU -->
<div id="Modau"></div>

## I. Mở đầu
* Sự phát triển như vũ bão của công nghệ thông tin (CNTT) đã tác động mạnh mẽ và to lớn đến mọi mặt đời sống kinh tế xã hội. Ngày nay, CNTT đã trở thành một trong những động lực quan trọng nhất của sự phát triển. Với khả năng số hóa mọi loại thông tin, máy tính trở thành phương tiện xử lý thông tin thống nhất và đa năng, thực hiện được nhiều chức năng khác nhau trên mọi dạng thông tin thuộc mọi lĩnh vực như: nghiên cứu, quản lý, kinh doanh, giáo dục, ...
* Những ứng dụng của CNTT trong lĩnh vực quản lý là những ứng dụng vô cùng quan trọng. Nó không những giải phóng công sức cho những người quản lý mà còn đem lại sự chính xác và nhanh nhạy trong quản lý. 
* Là sinh viên CNTT, trong đồ án môn Lập trình trực quan này, nhóm chúng em đã chọn và thực hiện đồ án “X Y DỰNG ỨNG DỤNG QUẢN LÝ THƯ VIỆN”.
Nhóm xin gửi lời cảm ơn chân thành đến thầy Nguyễn Tấn Toàn đã tận tình giảng dạy, hướng dẫn chúng em trong suốt thời gian học vừa qua và các bạn học đã góp ý và giúp đỡ nhóm trong quá trình thực hiện đồ án này.
Do kiến thức và thời gian thực hiện hạn chế, đồ án của nhóm vẫn còn nhiều thiếu sót. Nhóm rất mong nhận được góp ý của thầy và các bạn để đồ án của nhóm được hoàn thiện.

<!-- MÔ TẢ -->
<div id="Mota"></div>

## II. Mô tả

<!-- Ý TƯỞNG -->
<div id="Ytuong"></div>

### 1. Mô tả đề tài
* Đề tài "Hệ Thống Quản Lý Thư Viện" là một dự án phần mềm nhằm xây dựng một hệ thống toàn diện và hiệu quả giúp quản lý các hoạt động trong một thư viện. Đề tài này đặt ra mục tiêu cung cấp giải pháp thông minh cho việc quản lý thông tin về sách, người đọc và giao dịch mượn trả

* Xây dựng một ứng dụng phần mềm đa nhiệm và hiệu quả, giúp thư viện tổ chức thông tin sách, quản lý độc giả, và theo dõi quá trình mượn trả. Mục tiêu chính là tối ưu hóa các quy trình quản lý và cung cấp trải nghiệm thuận lợi cho cả người quản lý và độc giả.

* Sử dụng mô hình MVVM để tách giao diện và xử lý, tăng khả năng sử dụng lại các thành phần hoặc thay đổi giao diện chương trình mà không cần viết lại quá nhiều mã, bạn có thể phát triển ứng dụng, nâng cấp, bảo trì, mở rộng hoặc sửa chữa một cách nhanh chóng và dễ dàng.

* Công nghệ mã hóa Base64 và MD5Hásh được sử dụng trong quản lý tài khoản người dùng nhằm đảm bảo an toàn trong quá trình sử dụng và hạn chế tối đa tổn thất khi dữ liệu không may bị thất thoát ra bên ngoài.


<div id="Congnghe"></div>

### 2. Công nghệ
* Sử dụng ngôn ngữ C# kết hợp CSDL SQL Server
* Sử dụng ngôn ngữ XAML
* Entity Framework
* WPF


<div id="Doituongsudung"></div>

### 3. Đối tượng sử dụng
* Quản lý thư viện hoặc nhân viên thư viện: vai trò quản lý

<div id="Muctieu"></div>

### 4. Mục tiêu

* <strong>Ứng dụng thực tế</strong>
    
    * Đáp ứng yêu cầu của khách hàng, hệ thống có tính ổn định cao, dễ sử dụng, không gây khó khăn cho người dùng, được thiết kế đặc biệt cho khách hàng Việt Nam.

    * Được sử dụng rộng rãi trong các hệ thống thư viện, thay thế các ứng dụng cũ còn nhiều hạn chế, giao diện lỗi thời hay hình thức quản lý thủ công truyền thống cồng kềnh, khó quản lý, dễ xảy ra lỗi không đáng có.

    * Trở thành một trong những ứng dụng được khách hàng lựa chọn và tin tưởng.

 * <strong>Yêu cầu ứng dụng</strong>
 
    * Đáp ứng chức năng tiêu chuẩn theo yêu cầu của các ứng dụng quản lý thư viện hiện có trên thị trường. 

    * Nâng cao tính chính xác và bảo mật trong quản lý thông tin doanh nghiệp và khách hàng.

    * Việc lập báo cáo, thống kê, cập nhật dữ liệu, đồng bộ giữa các máy tính đều phải diễn ra nhanh chóng, chính xác.

    * Giao diện thân thiện, dễ sử dụng, bố cục hợp lý, màu sắc hài hòa, tính đồng bộ cao, phân quyền cho người dùng thông qua tài khoản.

    * Ứng dụng phải tương thích với hầu hết các hệ điều hành phổ biến như Windows Vista SP1, Window 8.1, Window 10, v.v.

<div id="Tinhnang"></div>

### 5. Tính năng
* Quản lý đăng nhập, hỗ trợ việc khôi phục tài khoản cho người dùng khi quên mật khẩu.

* Với vai trò quản lý (admin):

    * Quản lý sách: quản lý tất các loại sách có trong thư viện.​
 
    * Quản lý nhân viên: quản lý tất cả nhân viên làm việc trong thư viện.

    * Nhập sách: nhập thêm sách cho thư viện.​

    * Lịch sử: ghi lại tất cả các giao dịch xảy ra trong quá trình quản lý (nhập sách, mượn trả sách, thu phạt, thông tin mượn sách,  …).​

    * Mượn sách: ghi lại thông tin của người mượn và sách mượn.​

    * Sự cố: tiếp nhận những sự cố được đóng góp bởi khách hang và xử lý tình trạng sự cố.​

    * Cài đặt: thay đổi thông tin quản lý (mật khẩu,...)​

    * Quản lý độc giả: lưu lại thông tin của tất cả các độc giả. 
 
* Với vai trò nhân viên:
    * Quản lý sách: quản lý tất các loại sách có trong thư viện.​
 
    * Lịch sử: ghi lại tất cả các giao dịch xảy ra trong quá trình quản lý (nhập sách, mượn trả sách, thu phạt, thông tin mượn sách,  …).​

    * Mượn sách: ghi lại thông tin của người mượn và sách mượn.​

    * Sự cố: tiếp nhận những sự cố được đóng góp bởi khách hang và xử lý tình trạng sự cố.​

    * Cài đặt: thay đổi thông tin quản lý (mật khẩu,...)​

    * Quản lý độc giả: lưu lại thông tin của tất cả các độc giả. 
<!-- TÁC GIẢ -->
<div id="Tacgia"></div>

## III. Tác giả - Sinh viên thực hiện

* [Võ Minh Vũ](https://github.com/Vuvom1) - 21522808
    * Vai trò: Team learder, frontend developer, backend developer

* [Bùi Khánh Đang](https://github.com/22520187) - 22520187
    * Vai trò: Tester, frontend developer, backend developer

* [Đào Anh Tú](https://github.com/anhtu301003) - 
    * Vai trò: UI design, frontend developer, backend developer

<!-- NGƯỜI HƯỚNG DẪN -->
<div id="Nguoihuongdan"></div>

## IV. Giảng viên hướng dẫn
* Giảng viên: Nguyễn Tấn Toàn

<!-- TỔNG KẾT -->
<div id="Tongket"></div>

## V. Tổng kết
### Ưu điểm của đồ án
* Hoàn thiện về mặt giao diện và tính năng giúp tăng tính tiện dụng và thân thiện cho người dùng.

* Giao diện bắt mắt, cuốn hút người dùng.

* Có chức năng báo lỗi phần mềm để coder giải quyết


### Hạn chế của đồ án:

* Chưa có biểu đồ báo cáo, khiến cho người dùng khó khăn trong việc thống kê.


### Hướng  phát triển của đồ án:

* Thêm chức năng quản lý lương cho nhân viên

* Thêm chức năng thông báo cho độc giả khi sắp hết hạn mượn sách

* Thêm mục báo cáo thống kê cho dễ dàng quản lý

* Quản lý chi tiết lợi nhuận, chi phí trong mục thống kê.
---

<p align="right"><a href="#Top">Quay lại đầu trang</a></p>
