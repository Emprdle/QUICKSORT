<html>
<head>
<title>Databáze Emrle</title>
   </head>
   <body style="background-color:DeepSkyblue;">
      <h1>Terapeutická zvířata</h1>
      <p>Hlavní stránka</p>
      <a href="http://emrle.borec.cz/zobrazeni.php">Zobrazte své objednávky</a>
      <a href="http://emrle.borec.cz/zruseni.php">Zrušte své objednávky</a>
<style>
img {
  width: 200px;
  height: 150px;
}

td {
  text-align: left;
  vertical-align: left;
  padding:0 18px;
}
</style>

 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script> 
 <script>
 $(document).ready(function(){
 $(function(){
      var dtToday = new Date();
      var month = dtToday.getMonth() + 1;
      var day = dtToday.getDate();
      var year = dtToday.getFullYear();
      if(month < 10)
      {
        month = '0' + month.toString();
      } 
      if(day < 10)
      {
        day = '0' + day.toString();
      } 
      var maxDate = year + '-' + month + '-' + day;

      $('#dateControl').attr('min', maxDate);
  });
  })
 </script>


<form style="text-align: left "class="" action="index.php" method="post">
      <link rel="stylesheet" type="text/css" href="css/style.css">
      <table style="margin-left">
      	<tbody>
        <tr>
          <td>
            <a style=" width: 100px;" >Jméno: </a><input type="text" name="jmeno" placeholder = "Jméno">
          </td>
        </tr>
      	<tr>
          <td>
            <a style=" width: 100px;">Mail: </a><input type="email" name="mail" placeholder = "Mail">
          </td>
        </tr>
      	<tr>
          <td>
            <a style=" width: 100px;">id zvířete: </a><input type="text" name="id" placeholder = "zadejte id zvířete">
          </td>
        </tr>
        <tr>
          <td>
            <a style=" width: 100px;">Datum rezervace: </a><input type="date" id="dateControl" name="datum" ></td>
          </tr>
      	<tr>
          <td>
            <input type="submit" name="zarezervovatslužbu" value="Rezervace zvířete">
          </td>
        </tr>
       </tbody>
      </table>
    </form>

<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<!-- <link rel="stylesheet" href="lightbox.min.css"> -->
</head>
<body>
<?php
$servername = "sql5.webzdarma.cz:3306";  //sql5.webzdarma.cz:3306
$username = "emrleboreccz1128";          //emrleboreccz1128
$password = "&y7GuEsogk&B_l@X)GJL";      //	&y7GuEsogk&B_l@X)GJL
$dbname = "emrleboreccz1128";            //emrleboreccz1128
$conn = mysqli_connect($servername, $username, $password, $dbname);


if (!$conn) {
    die("Pripojení selhalo: " . mysqli_connect_error());
}

  
  
  
 
    $sql4 = 'SELECT * FROM objednane WHERE datum="'.$_POST['datum'].'" and nabid_id='.$_POST['id'].';';
    $result4 = $conn->query($sql4);
    
    if($result4->num_rows > 0)
    { 
      echo "<script>alert('Tohle zvíře už je na tento den rezervováno, vyberte prosím jiný den.');</script>";
    } 
    else
    {
      if(!empty($_POST["id"]) && !empty($_POST["jmeno"]) && !empty($_POST["mail"]) && !empty($_POST["datum"]))
      {
        $sql = 'INSERT INTO objednane (nabid_id,jmeno,email,datum) 
        VALUES ('.$_POST["id"].', "'.$_POST["jmeno"].'", "'.$_POST["mail"].'", "'.$_POST["datum"].'")';
        $result = $conn->query($sql);
      }
      
      if($result)
      {
      echo "<script>alert('Vyčkejte na mail o schválení objednávky');</script>";
      $msg = "dobrý den, " . $_POST["jmeno"] . " \nVaše rezervace zvířete s id " . $_POST["id"] . "\nna datum " . $_POST["datum"] . " byla přijata\nPro zrušení objednávky vyplnte formulář na následujícím odkazu: http://emrle.borec.cz/zruseni.php\nPro pro zobrazení vašich rezervací vyplnte formulář na následujícím odkazu: http://emrle.borec.cz/zobrazeni.php";

      // use wordwrap() if lines are longer than 70 characters
      $msg = wordwrap($msg,70);

      // send email
      mail($_POST["mail"],"objednávka terapeutické zvěře pro: " . $_POST["jmeno"],$msg);
      }
      if(isset($_POST["zarezervovatslužbu"]))
      {
        if(empty($_POST['mail']) || empty($_POST['jmeno']) || empty($_POST['id']) || empty($_POST['datum']))
        {
          echo "<script>alert('Nemáte vyplněné všechny údaje.');</script>";
        }
        else if( $_POST["id"] != 1 && $_POST["id"] != 2 && $_POST["id"] != 3 && $_POST["id"] != 4 && $_POST["id"] != 5 && $_POST["id"] != 6 
        && $_POST["id"] != 7 && $_POST["id"] != 8 && $_POST["id"] != 9 && $_POST["id"] != 10 )
        {
          echo "<script>alert('id zvířete neexistuje.');</script>";
        }
      }
      
    }
    
$sql = "SELECT id, fotkaproduktu, nazev, cena FROM zvirata";  
if($result = mysqli_query($conn, $sql)){
    if(mysqli_num_rows($result) > 0){
        echo "<table>";
            echo "<thead>"; //tr
                echo "<th><h3> id </h3></th>";
                echo "<th><h3> fotka <h3</th>";
                echo "<th><h3> název <h3</th>";
                echo "<th><h3> Cena (kč) <h3</th>";

            echo "</thead>";
            echo "<tbody>"; 
        while($row = mysqli_fetch_array($result)){
            echo "<tr>";
                echo "<td>" . $row['id'] . "</td>";
                echo "<td><a href=".$row['fotkaproduktu']." ><img src='".$row['fotkaproduktu']."'></a></td>"; 

                echo "<td>" . $row['nazev'] . "</td>";
                echo "<td>" . $row['cena'] . "</td>";   
        }
        echo "</tbody>"; 
        echo "</table>";
        mysqli_free_result($result);
    }    }    
mysqli_close($conn);



?>

<!-- <script src="lightbox-plus-jquery.min.js"></script> -->
</body>
</html>  