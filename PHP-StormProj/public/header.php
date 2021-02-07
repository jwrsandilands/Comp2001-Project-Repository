<?php date_default_timezone_set('Europe/London');
?>

<!doctype html>
<html lang="en">
    <head>
        <meta charset='utf-8'>
        <link rel="stylesheet" href="assets\css\Formatting.css">
        <style>ul#menu li{display:inline; padding: 10px 10px}</style>
        <title><?=isset($PageTitle) ? $PageTitle : "Comp2001 Web Project"?></title>
    </head>
<body>
    <nav>
        <h2>Comp2001 Web Project</h2>
        <h1><?echo basename($_SERVER['PHP_SELF'])?></h1>
    </nav>
    <nav>

        <ul id="menu">
            <li><a href="index.php">HOME</a></li>
            <li><a href="data.php">DATA</a></li>
        </ul>

    </nav>

</body>
</html>