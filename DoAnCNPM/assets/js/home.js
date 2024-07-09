// Hàm này sẽ được gọi khi một nút được click
function buttonClicked(clickedElement) {
    // Tìm tất cả các nút có lớp 'page_product_number_item_clicked'
    var buttons = document.querySelectorAll('.page_product_number_item_clicked');

    // Xóa lớp 'page_product_number_item_clicked' khỏi tất cả các nút
    buttons.forEach(function (button) {
        button.classList.remove('page_product_number_item_clicked');
    });

    // Thêm lớp 'page_product_number_item_clicked' vào nút vừa được click
    clickedElement.classList.add('page_product_number_item_clicked');
}