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


document.addEventListener('DOMContentLoaded', function () {
    select()
    searchQuery()
})
function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')
                selected.setAttribute('data-value', category)
                updateCoursesByFilters()
            })
        })
    }
    catch { }
}

function searchQuery() {
    try {
        document.querySelector('#searchQuery').addEventListener('keyup', function () {
            updateCoursesByFilters()
        })
    }
    catch { }
}

function updateCoursesByFilters() {
    const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
    const searchQuery = document.querySelector('#searchQuery').value

    const url = `/course/courses?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchQuery)}`

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            document.querySelector('.grid').innerHTML = dom.querySelector('.grid').innerHTML
        })
}