const mobileBtn = document.querySelector('.btn-mobile')

mobileBtn.addEventListener('click', () => {
    const menu = document.querySelector('#mobile-menu')
    menu.classList.toggle('open')
})



document.addEventListener('DOMContentLoaded', function () {
    let sw = document.querySelector('#switch-mode')

    sw.addEventListener('change', function () {
        let theme = this.checked ? "dark" : "light"


        fetch(`/sitesettings/changetheme?mode=${theme}`)
            .then(res => {
                if (res.ok)
                    window.location.reload()
                else 
                console.log('something')
            })

    })
})