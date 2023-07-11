<?php

@include 'config.php';

session_start();

$user_id = $_SESSION['user_id'];

if(!isset($user_id)){
   header('location:login.php');
};

if(isset($_POST['order'])){

    $name = mysqli_real_escape_string($conn, $_POST['name']);
    $number = mysqli_real_escape_string($conn, $_POST['number']);
    $email = mysqli_real_escape_string($conn, $_POST['email']);
    $method = mysqli_real_escape_string($conn, $_POST['method']);
    $address = mysqli_real_escape_string($conn, $_POST['adress'].', '. $_POST['city'].', '. $_POST['number']);
    $placed_on = date('d-M-Y');

    $cart_total = 0;
    $cart_products[] = '';

    $cart_query = mysqli_query($conn, "SELECT * FROM `cart` WHERE user_id = '$user_id'") or die('Запрос не удался!');
    if(mysqli_num_rows($cart_query) > 0){
        while($cart_item = mysqli_fetch_assoc($cart_query)){
            $cart_products[] = $cart_item['name'].' ('.$cart_item['quantity'].') ';
            $sub_total = ($cart_item['price'] * $cart_item['quantity']);
            $cart_total += $sub_total;
        }
    }

    $total_products = implode(', ',$cart_products);

    $order_query = mysqli_query($conn, "SELECT * FROM `orders` WHERE name = '$name' AND number = '$number' AND email = '$email' AND method = '$method' AND address = '$address' AND total_products = '$total_products' AND total_price = '$cart_total'") or die('Запрос не удался!');

    if($cart_total == 0){
        $message[] = 'Пока что здесь пусто!';
    }elseif(mysqli_num_rows($order_query) > 0){
        $message[] = 'Заказ уже выполнен!';
    }else{
        mysqli_query($conn, "INSERT INTO `orders`(user_id, name, number, email, method, address, total_products, total_price, placed_on) VALUES('$user_id', '$name', '$number', '$email', '$method', '$address', '$total_products', '$cart_total', '$placed_on')") or die('Запрос не удался!');
        mysqli_query($conn, "DELETE FROM `cart` WHERE user_id = '$user_id'") or die('Запрос не удался!');
        $message[] = 'Оплата успешно выполнена. Ждите звонка менеджера!';
    }
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
<link rel="icon" href="images/icon.png">
   <meta charset="UTF-8">
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>Оплата</title>

   <!-- font awesome cdn link  -->
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">

   <!-- custom admin css file link  -->
   <link rel="stylesheet" href="css/style.css">

</head>
<body>
   
<?php @include 'header.php'; ?>

<section class="heading">
    <h3>Оплата заказа</h3>
    <p> <a href="home.php">Главная</a> / Оплата </p>
</section>

<section class="display-order">
    <?php
        $grand_total = 0;
        $select_cart = mysqli_query($conn, "SELECT * FROM `cart` WHERE user_id = '$user_id'") or die('Запрос не удался!');
        if(mysqli_num_rows($select_cart) > 0){
            while($fetch_cart = mysqli_fetch_assoc($select_cart)){
            $total_price = ($fetch_cart['price'] * $fetch_cart['quantity']);
            $grand_total += $total_price;
    ?>    
    <p> <?php echo $fetch_cart['name'] ?> <span>(<?php echo $fetch_cart['price'].' Лей'.' x '.$fetch_cart['quantity']  ?>)</span> </p>
    <?php
        }
        }else{
            echo '<p class="empty">Пока что здесь пусто!</p>';
        }
    ?>
    <div class="grand-total">Итого : <span><?php echo $grand_total; ?> Лей</span></div>
</section>

<section class="checkout">

    <form action="" method="POST">

        <h3>Оформите свой заказ</h3>

        <div class="flex">
            <div class="inputBox">
                <span>Имя :</span>
                <input type="text" name="name" placeholder="Введите ваше имя...">
            </div>
            <div class="inputBox">
                <span>Номер телефона :</span>
                <input type="number" name="number" min="0" placeholder="Введите ваш номер телефона">
            </div>
            <div class="inputBox">
                <span>Email :</span>
                <input type="email" name="email" placeholder="Введите ваш почтоый адрес">
            </div>
            <div class="inputBox">
                <span>Способ оплаты :</span>
                <select name="method">
                    <option value="Наличными при получении">Наличными при получении</option>
                    <option value="Банковская карта">Банковская карта</option>
                </select>
            </div>
            
            <div class="inputBox">
                <span>Город :</span>
                <input type="text" name="city" placeholder="Н-р Кишинев">
            </div>
            <div class="inputBox">
                <span>Адрес :</span>
                <input type="text" name="adress" placeholder="Н-р Алеко Руссо 9, кв. 13">
            </div>
        </div>

        <input type="submit" name="order" value="Заказать сейчас" class="btn">

    </form>
</section>
<?php @include 'footer.php'; ?>
<script src="js/script.js"></script>
</body>
</html>