<?php

@include 'config.php';

session_start();

$user_id = $_SESSION['user_id'];

if(!isset($user_id)){
   header('location:login.php');
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
   <link rel="icon" href="images/icon.png">
   <meta charset="UTF-8">
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>О нас</title>

   <!-- font awesome cdn link  -->
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">

   <!-- custom admin css file link  -->
   <link rel="stylesheet" href="css/style.css">

</head>
<body>
   
<?php @include 'header.php'; ?>

<section class="heading">
    <h3>О нас</h3>
    <p> <a href="home.php">Главная</a> / О нас </p>
</section>

<section class="about">

    <div class="flex">

        <div class="image">
            <img src="images/about_img1.jpg" alt="">
        </div>

        <div class="content">
            <h3>Кто мы?</h3>
            <p>Встречайте Flostilux; мы гораздо больше, чем просто служба доставки цветов. Рожденные из потребности познакомить клиентов во всем мире с самыми лучшими сортами сезонных цветов, мы предлагаем нотку цветочной роскоши для любого случая, будь то особый день или каждый день. Всегда самого высокого качества, всегда из экологически чистых источников и всегда экстраординарно. Это путь Flostilux.</p>
            <a href="shop.php" class="btn">Узнать больше</a>
        </div>

    </div>

    <div class="flex">

        <div class="content">
            <h3>Что мы делаем?</h3>
            <p>Больше, чем цветы, в Flostilux мы постоянно развиваемся как идеальное пространство для удовлетворения потребностей тех, кто любит цветы. Удовлетворение потребностей клиентов - наша главная цель. Это основа всего, что мы делаем, и всего, чем мы являемся.</p>
            <a href="contact.php" class="btn">Заказать букет</a>
        </div>

        <div class="image">
            <img src="images/about_img2.jpg" alt="">
        </div>
    </div>

    <div class="flex">
        <div class="image">
            <img src="images/about_img3.jpg" alt="">
        </div>

        <div class="content">
            <h3>Пространство Flostilux</h3>
            <p>Как знатоки всего цветочного, мы хотим поделиться с вами нашим опытом. От нас вы можете ожидать всего: от простых решений по укладке стеблей до советов экспертов по уходу, которые позволят вашим цветам выглядеть наилучшим образом еще дольше, в наших тщательно подобранных руководствах и многом другом.</p>
            <a href="#reviews" class="btn">Отзывы клиентов</a>
        </div>
    </div>
</section>

<section class="reviews" id="reviews">

    <h1 class="title">Отзывы клиентов</h1>

    <div class="box-container">
        <div class="box">
            <img src="images/b.jpg" alt="">
            <p>Просто потрясающий интернет-магазин, шикарный выбор цветов, удивил выбор экзотических цветов, очень вежливый персонал, ребята творят просто чудесные букеты, это единственное место где я смог заказать букет в два часа ночи.</p>
            <div class="stars">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
            </div>
            <h3>Евгений Морозов</h3>
        </div>

        <div class="box">
            <img src="images/aa.jpg" alt="">
            <p>Флористы улыбчивые и позитивные! Мне собрали бесподобный букет на юбилей моей мамы. Она была просто в восторге, с букетом получились классные фотографии. К слову, они очень долго стояли и радовали нас. В следующий раз я знаю, куда идти за букетом.</p>
            <div class="stars">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
            </div>
            <h3>Екатерина Алая</h3>
        </div>

        <div class="box">
            <img src="images/a.jpg" alt="">
            <p>Спасибо за красивый букет, за своевременную доставку и помощь с оформлением заказа! Находясь за границей были трудности с оплатой, но мне помогли. Самое главное - девушка была в восторге от сюрприза! Радуйте своих женщин))</p>
            <div class="stars">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star-half-alt"></i>
            </div>
            <h3>Алексей Сандакчи</h3>
        </div>

        <div class="box">
            <img src="images/bb.jpg" alt="">
            <p>Прежде всего большое спасибо оператору Дарье. Оперативность, знание своего дела помогла справиться с проблемой, заменить на другой букет и так быстро доставить. Будьте внимательны, заранее оговаривайте наличие букета и просите фото перед отправкой. Спасибо.</p>
            <div class="stars">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star-half-alt"></i>
            </div>
            <h3>Мария Крылова</h3>
        </div>
        <div class="box">
            <img src="images/c.jpg" alt="">
            <p>Заказал девушке букет пионов. Очень доволен тем, что выбрал именно их для доставки цветов. Приемлемые цены, удобная форма заказа через сайт, очень легко, всё быстро и отлично организовано. Пионы свежие, в бутонах, стояли больше недели. Девушка осталась счастлива.</p>
            <div class="stars">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
            </div>
            <h3>Мирон Ширяев</h3>
        </div>
        <div class="box">
            <img src="images/cc.jpg" alt="">
            <p>Сегодня впервые заказала цветы с сайта, всегда предпочитала видеть цветы в живую. Осталась безмерно довольна, букет как на фото, заказывала в подарок, мне прислали фото перед отправкой, все идеально. Большое спасибо, за прекрасный букет и профессиональную работу!</p>
            <div class="stars">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
            </div>
            <h3>Анастасия Малинова</h3>
        </div>
    </div>
</section>
<?php @include 'footer.php'; ?>
<script src="js/script.js"></script>
</body>
</html>