<html>
<head>
<title>Databáze Emrle</title>
   </head>
   <body style="background-color:DeepSkyblue;">
      <h1>Zobrazení objednávek</h1>
      <p>Terapeutická zvířata</p>
      <a href="http://emrle.borec.cz/index.php">Hlavní stránka</a>

<form style="text-align: left "class="" action="zobrazeni.php" method="post">
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
            <input type="submit" name="zarezervovatslužbu" value="Zobrazení rezervací zákazníka">
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



if(!empty($_POST["jmeno2"]) && !empty($_POST["mail2"]))
  {
    $sql = 'SELECT nabid_id,jmeno,email,datum FROM objednane WHERE jmeno="'.$_POST['jmeno2'].'" and email="'.$_POST['mail2'].'";';  
    

    if($result = mysqli_query($conn, $sql)){
    if(mysqli_num_rows($result) > 0){
        echo "<table>";
            echo "<thead>"; //tr
                echo "<th><h3> id vybrané zvěře </h3></th>";
                echo "<th><h3> jméno zákazníka <h3</th>";
                echo "<th><h3> email zákazníka <h3</th>";
                echo "<th><h3> datum, na kdy je zvěř rezervovaná <h3</th>";

            echo "</thead>";
            echo "<tbody>"; //
        while($row = mysqli_fetch_array($result)){
            echo "<tr>";
                echo "<td>" . $row['nabid_id'] . "</td>";
                echo "<td>" . $row['jmeno'] . "</td>";
                echo "<td>" . $row['email'] . "</td>";
                echo "<td>" . $row['datum'] . "</td>";
        }
        echo "</tbody>"; //
        echo "</table>";
        mysqli_free_result($result);
    }
      }    
mysqli_close($conn);
  }

  
    if(isset($_POST["zarezervovatslužbu"]))
    {
     if(empty($_POST['mail2']) || empty($_POST['jmeno2']))
     {
       echo "<script>alert('Nemáte vyplněné všechny údaje.');</script>";
     }
    }
  

?>
</body>
</html> 