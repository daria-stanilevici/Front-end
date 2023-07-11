<?php

@include 'config.php';

session_start();

$admin_id = $_SESSION['admin_id'];

if(!isset($admin_id)){
   header('location:login.php');
};

if(isset($_GET['delete'])){
   $delete_id = $_GET['delete'];
   mysqli_query($conn, "DELETE FROM `users` WHERE id = '$delete_id'") or die('Запрос не удался!');
   header('location:admin_users.php');
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
<link rel="icon" href="images/icon.png">
   <meta charset="UTF-8">
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>Пользователи</title>

   <!-- font awesome cdn link  -->
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">

   <!-- custom admin css file link  -->
   <link rel="stylesheet" href="css/admin_style.css">

</head>
<body>
   
<?php @include 'admin_header.php'; ?>

<section class="users">

   <h1 class="title">Аккаунты</h1>

   <div class="box-container">
      <?php
         $select_users = mysqli_query($conn, "SELECT * FROM `users`") or die('Запрос не удался!');
         if(mysqli_num_rows($select_users) > 0){
            while($fetch_users = mysqli_fetch_assoc($select_users)){
      ?>
      <div class="box">
         <p>Id пользователя : <span><?php echo $fetch_users['id']; ?></span></p>
         <p>Логин : <span><?php echo $fetch_users['name']; ?></span></p>
         <p>Email : <span><?php echo $fetch_users['email']; ?></span></p>
         <p>Роль : <span style="color:<?php if($fetch_users['user_type'] == 'admin'){ echo 'var(--pink)'; }; ?>"><?php echo $fetch_users['user_type']; ?></span></p>
         <a href="admin_users.php?delete=<?php echo $fetch_users['id']; ?>" onclick="return confirm('Удалить этого пользователя?');" class="delete-btn">Удалить</a>
      </div>
      <?php
         }
      }
      ?>
   </div>

</section>













<script src="js/admin_script.js"></script>

</body>
</html>