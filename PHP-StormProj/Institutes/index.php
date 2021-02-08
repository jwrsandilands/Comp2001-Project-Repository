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
    <h5>Below is the data Entity and general linked data style information. You can use the inspect element on your browser to see how all the content is linked together in branches!</h5>
</div>
<div class = "container-sm">
<?php

    $row = 1;
    if(($inLinkedData = fopen("../public/resources_cd162ad1-d7d5-42a9-b1ab-0edbcd697f1e_air-quality-by-pm2.5-score-blf.org.uk.csv", "r")) !== FALSE) {
        while (($dataLine = fgetcsv($inLinkedData, 1000, ",")) !== FALSE) {
            echo "<div vocab=\"https://schema.org/\" resource=\"#Medical Institute\" typeof=\"Place\">";
            echo "<h2 property=\"name\">" . $dataLine[0] . "</h2>";
            echo "<span property=\"alternateName\">" . $dataLine[4] . "</span><h5></h5>";
            echo "<div property=\"address\" resource=\"#address\" typeof=\"PostalAddress\">";
            echo "<span property = \"streetAddress\">". $dataLine[1] ."</span><h5></h5>";
            echo "<span property=\"addressRegion\">". $dataLine[3] ."</span><h5></h5>";
            echo "<span property = \"postalCode\">". $dataLine[2]."</span><h5></h5>";
            echo "</div>";
            echo "<span property=\"description\">" . $dataLine[5] . "</span><h5></h5>";
            echo "<span property=\"latitude\">" . $dataLine[7] . "</span><h5></h5>";
            echo "<span property=\"longitude\">" . $dataLine[8] . "</span><h5></h5>";
            echo "</div>";
//            echo $dataLine;
        }
    }
    fclose($inLinkedData);
//    var_dump($inLinkedData);
//    echo $inLinkedData[1][0];

?>
</div>
<!--<div vocab="https://schema.org/" resource="#Medical Institute" typeof="Place">-->
<!--    <h1 property="name">West Hoe Surgery</h1>-->
<!--    <span property="alternateName">GP Practice</span>-->
<!--    <div property="address" resource="#address" typeof="PostalAddress">-->
<!--        <span property = "streetAddress">West Hoe Surgery, 2 Cliff Road, Plymouth, Devon</span>-->
<!--        <span property="addressRegion">St Pete and the Waterfront</span>,-->
<!---->
<!--    </div>-->
<!---->
<!--    <span property="latitude">50.36483369</span>-->
<!--    <span property="longitude">-4.150356164</span>-->
<!--</div>-->

<?php
require_once '../public/footer.php';
?>