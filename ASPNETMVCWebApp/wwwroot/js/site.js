const mobileBtn = document.querySelector('.btn-mobile')

mobileBtn.addEventListener('click', () => {
    const menu = document.querySelector('#mobile-menu')
    menu.classList.toggle('open')
})