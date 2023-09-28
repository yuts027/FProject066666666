
//首頁使用

AOS.init();

//固定按鈕
window.onscroll = function () {
  if (window.pageYOffset > 400) {
    document.getElementById("gotop").style.display = "block";
    document.getElementById("booking").style.display = "block";
  } else {
    document.getElementById("gotop").style.display = "none";
    document.getElementById("booking").style.display = "none";
  }
};

function scrollToTop() {
  window.scrollTo({ top: 0, behavior: 'smooth' });
}


//最新消息自動跳動
  const descriptions = document.querySelectorAll('.description');
  let currentIndex = 0;

  function updateCarousel() {
    descriptions.forEach((description, index) => {
      if (index === currentIndex) {
        description.classList.add('active');
      } else {
        description.classList.remove('active');
      }
    });
    

    currentIndex = (currentIndex + 1) % descriptions.length;
  }
  updateCarousel();

  setInterval(updateCarousel, 5000); 



