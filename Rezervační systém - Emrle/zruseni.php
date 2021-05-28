<html>
<head>
<title>Databáze Emrle</title>
   </head>
   <body style="background-color:DeepSkyblue;">
      <h1>Zrušení objednávek</h1>
      <p>Terapeutická zvířata</p>
      <a href="http://emrle.borec.cz/index.php">Hlavní stránka</a>


<form style="text-align: left "class="" action="zruseni.php" method="post">
      <link rel="stylesheet" type="text/css" href="css/style.css">
      <table style="margin-left">
      	<tbody>

        <tr>
          <td>
            <a style=" width: 100px;">Jméno: </a><input type="text" name="jmeno2" placeholder = "Jméno">
          </td>
        </tr>
      	<tr>
          <td>
            <a style=" width: 100px;">Mail: </a><input type="email" name="mail2" placeholder = "mail">
          </td>
        </tr>
        <tr>
          <td>
            <a style=" width: 100px;">id zvířete: </a><input type="text" name="id2" placeholder = "zadejte id zvířete"></td>
          </tr>
      	<tr>
          <td>
            <a style=" width: 100px;">Datum rezervace: </a><input type="date" name="datum2" >
          </td>
        </tr>
      	<tr>
          <td>
            <input type="submit" name="zarezervovatslužbu" value="Zrušení rezervace zvířete">
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

//if (isset($_POST['submit']))

if (!$conn) 
{
    die("Pripojení selhalo: " . mysqli_connect_error());
}


  if(!empty($_POST["id2"]) && !empty($_POST["jmeno2"]) && !empty($_POST["mail2"]) && !empty($_POST["datum2"]))
  {

    $sql3 = 'SELECT * FROM objednane WHERE datum="'.$_POST['datum2'].'" and nabid_id='.$_POST['id2'].' and email="'.$_POST['mail2'].'" and jmeno="'.$_POST['jmeno2'].'";';
    $result3 = $conn->query($sql3);
    
    if($result3->num_rows > 0)
    { 
      $sql2 = 'DELETE FROM objednane WHERE datum="'.$_POST['datum2'].'" and nabid_id='.$_POST['id2'].' and email="'.$_POST['mail2'].'" and jmeno="'.$_POST['jmeno2'].'";';
      $result2 = $conn->query($sql2);
    } 
    if($result2) 
    {
      echo "<script>alert('smazána');</script>";
    }
 
    else 
    {
      echo "<script>alert('Objednávka nesmazána, vaše zadané údaje jsou chybné');</script>";
    }
  }

?>
</body>
</html>  