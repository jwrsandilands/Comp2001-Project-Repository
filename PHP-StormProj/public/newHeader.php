<?php date_default_timezone_set('Europe/London');
?>

<html lang="en">
<head>
    <meta charset='utf-8'>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">
    <style>ul#menu li{display:inline; padding: 10px 10px}</style>
    <style>.square {
            background: #d8e9e6;
            width: 50vw;
            height: 50vw;
        }
    </style>
    <title><?=isset($PageTitle) ? $PageTitle : "Comp2001 Web Project"?></title>
</head>
<body>
<div class = "container">
    <nav class="p-3 mb-2 bg-primary text-white">
        <h1 class="p-3 mb-2 bg-primary text-white"><p><strong>Comp2001 Web project: <?echo basename($_SERVER['PHP_SELF'])?></strong></p></h1>
        <ul id = menu class="p-3 mb-2 bg-light">
            <li class><a href="../public/index.php">HOME</a></li>
            <li class><a href="../public/data.php">DATA</a></li>
            <li class><a href="../Institutes/index.php">ENTITIES</a></li>
            <li class><a href="../public/further.php">FURTHER READING</a></li>
        </ul>
    </nav>
</div>
</body>
</html>
