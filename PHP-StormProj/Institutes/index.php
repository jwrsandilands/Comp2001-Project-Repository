<?php
require_once '../public/newHeader.php';
?>
<html lang="en">
<head>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">
</head>
<body>
<div class = "container-sm">
    <h4>⠀</h4>
</div>
<div class = "container-sm">
    <h1><p><strong>Entities!</strong></p></h1>
    <h5>Below is the data Entity and general linked data style information.</h5>
</div>
<?php

    $row = 1;
    if(($readLines = fopen("../public/resources_cd162ad1-d7d5-42a9-b1ab-0edbcd697f1e_air-quality-by-pm2.5-score-blf.org.uk.csv", "r")) !== FALSE) {
        while (($dataLine = fgetcsv($readLines, 1000, ",")) !== FALSE) {
            echo "<div vocab=\"https://schema.org/\" resource=\"#Medical Institute\" typeof=\"Place\">";
            echo "<h1 property=\"name\">" . $dataLine[0] . "</h1>";
            echo "<span property=\"alternateName\">" . $dataLine[4] . "</span>";
            echo "<div property=\"address\" resource=\"#address\" typeof=\"PostalAddress\">";
                echo "<span property = \"streetAddress\">". $dataLine[1] ."</span>";
                echo "<span property=\"addressRegion\">. $dataLine[3] .</span>,";
                echo "<span property = \"postalCode\">. $dataLine[2].</span>";
            echo "<span property=\"description\"> . $dataLine[5] . </span>";
            echo "<span property=\"latitude\"> . $dataLine[7] . </span>";
            echo "<span property=\"longitude\"> . $dataLine[8] . </span>";

//            echo $dataLine;

        }
    }
    fclose($readLines);
    var_dump($readLines);

?>

<div vocab="https://schema.org/" resource="#Medical Institute" typeof="Place">
    <h1 property="name">West Hoe Surgery</h1>
    <span property="alternateName">GP Practice</span>
    <div property="address" resource="#address" typeof="PostalAddress">
        <span property = "streetAddress">West Hoe Surgery, 2 Cliff Road, Plymouth, Devon</span>
        <span property="addressRegion">St Pete and the Waterfront</span>,

    </div>

    <span property="latitude">50.36483369</span>
    <span property="longitude">-4.150356164</span>
</div>

<?php
require_once '../public/footer.php';
?>