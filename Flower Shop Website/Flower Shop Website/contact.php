<?php

@include 'config.php';

session_start();

$user_id = $_SESSION['user_id'];

if(!isset($user_id)){
   header('location:login.php');
};

if(isset($_POST['send'])){

    $name = mysqli_real_escape_string($conn, $_POST['name']);
    $email = mysqli_real_escape_string($conn, $_POST['email']);
    $number = mysqli_real_escape_string($conn, $_POST['number']);
    $msg = mysqli_real_escape_string($conn, $_POST['message']);

    $select_message = mysqli_query($conn, "SELECT * FROM `message` WHERE name = '$name' AND email = '$email' AND number = '$number' AND message = '$msg'") or die('Запрос не удался!');

    if(mysqli_num_rows($select_message) > 0){
        $message[] = 'Сообщение уже отправлено!';
    }else{
        mysqli_query($conn, "INSERT INTO `message`(user_id, name, email, number, message) VALUES('$user_id', '$name', '$email', '$number', '$msg')") or die('Запрос не удался!');
        $message[] = 'Сообщение успешно отправлено!';
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
   <title>Свяжись с нами</title>

   <!-- font awesome cdn link  -->
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">

   <!-- custom admin css file link  -->
   <link rel="stylesheet" href="css/style.css">

</head>
<body>
   
<?php @include 'header.php'; ?>

<section class="heading">
    <h3>Свяжись с нами</h3>
    <p> <a href="home.php">Главная</a> / Контакты </p>
</section>

<section class="contact">
    <form action="" method="POST">
        <h3>Отправь нам сообщение!</h3>
        <input type="text" name="name" placeholder="Имя" class="box" required> 
        <input type="email" name="email" placeholder="Email" class="box" required>
        <input type="number" name="number" placeholder="Телефон" class="box" required>
        <textarea name="message" class="box" placeholder="Ваше сообщение..." required cols="30" rows="10"></textarea>
        <input type="submit" value="Отправить" name="send" class="btn">
    </form>
</section>
<?php @include 'footer.php'; ?>
<script src="js/script.js"></script>
</body>
</html>