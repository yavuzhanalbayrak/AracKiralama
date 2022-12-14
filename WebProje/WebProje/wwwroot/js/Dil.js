
$(document).ready(function () {

    var arrLang = {

        'tr': {

            '1': 'Arabalar',
            '2': 'Ticari Araçlar',
            '3': 'Kamyonlar',
            '4': 'Motorlar',
            '5': 'Tekneler',
            '6': 'Kiralanan',
            '7': 'Çıkış',
            '8': 'Ana Sayfa',
            '9': 'EN UYGUN',
            '10': 'Eğer en uygun fiyatlı aracı kiralayarak seyahat etmek istiyorsanız, doğru yerdesiniz. Rent a Car’da size en uygun araçlar sadece birkaç tık uzağınızda. Yüzlerce aracı Türkiye’nin tüm noktalarına ulaştırdığımızdan istediğiniz yere en uygun fiyatlı araçlarla gidebilirsiniz.',
            '11': "GÜVENİLİR",
            '12': "Tüm ödeme işlemleriniz, dünyanın önde gelen güvenlik sertifikası şirketleri tarafından koruma altındadır.",
            '13': 'HIZLI ve KOLAY',
            '14': 'Rent a Car sayesinde size en uygun araçları birkaç tıkla hızla ve kolayca kiralayın.',
            '15': 'Marka',
            '16': 'Yıl',
            '17': 'Renk',
            '18': 'Filtrele',
            '19': 'Kiralanan Araçlar',
            '20': 'Araç Id',
            '21': 'Geri Dön',
            '22': 'Giriş',
            '23': 'Kaydol',
            '24': "Kullanıcı Adı:",
            '25': "Şifre:",
            '26': 'İçeriğin yeniden boyutlandırmaya nasıl yanıt verdiğini görmek için tarayıcı penceresini yeniden boyutlandırın.'



        },


        'en': {
            
            '1': 'Cars',
            '2': 'Off-Roads',
            '3': 'Trucks',
            '4': 'Motocycles',
            '5': 'Ships',
            '6': 'Rent',
            '7': 'Exit',
            '8': 'Home Page',
            '9': 'OPTIMAL',
            '10': 'If you want to travel by renting the most affordable vehicle, you are at the right place. At Rent a Car, the most suitable vehicles for you are just a few clicks away. Since we deliver hundreds of vehicles to all points of Turkey, you can go wherever you want with the most affordable vehicles.',
            '11': 'SECURE',
            '12': "All your payment transactions are protected by the world's leading security certification companies.",
            '13': 'FAST and EASY',
            '14': 'Rent a car quickly and easily with a few clicks thanks to Rent a Car.',
            '15': 'Brand',
            '16': 'Year',
            '17': 'Color',
            '18': 'Filter',
            '19': 'Rented Vehicles',
            '20': 'Vehicle Id',
            '21': 'Back to List',
            '22': 'Login',
            '23': 'Sign up',
            '24': "Username:",
            '25': "Password:",
            '26': 'İçeriğin yeniden boyutlandırmaya nasıl yanıt verdiğini görmek için tarayıcı penceresini yeniden boyutlandırın.'

        },


    };



    $('.dropdown-item').click(function () {
        localStorage.setItem('dil', JSON.stringify($(this).attr('id')));
        location.reload();
    });

    var lang = JSON.parse(localStorage.getItem('dil'));

    if (lang == "en") {
        $("#drop_yazı").html("Language");
    }
    else {
        $("#drop_yazı").html("Dil");

    }

    $('a,div,h5,p,h1,h2,h4,span,li,button,h3,label,th,input').each(function (index, element) {
        $(this).text(arrLang[lang][$(this).attr('key')]);

    });

});
