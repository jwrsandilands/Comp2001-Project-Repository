<?php
require_once 'public/newHeader.php';
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
        <h1><p><strong>Data!</strong></p></h1>
        <h5>Below is the data table represented from a CSV file.</h5>
    </div>
    <div class = "container-sm">
        <h4>⠀</h4>
    </div>
        <table class = "table">
            <thread>
                <tr>
                    <th scope = "col">#</th>
                    <th scope = "col">Name</th>
                    <th scope = "col">Address</th>
                    <th scope = "col">Postcode</th>
                    <th scope = "col">Town</th>
                    <th scope = "col">Type</th>
                    <th scope = "col">PM2 5</th>
                    <th scope = "col">Exceeds 10</th>
                    <th scope = "col">Latitude</th>
                    <th scope = "col">Longitude</th>
                </tr>
            </thread>
            <tbody>
            <?php
            $row = 1;
            if (($readLines = fopen("public/resources_cd162ad1-d7d5-42a9-b1ab-0edbcd697f1e_air-quality-by-pm2.5-score-blf.org.uk.csv", "r")) !== FALSE) {
                while (($dataLine = fgetcsv($readLines, 1000, ",")) !== FALSE) {
                    echo "<tr>";
                    $numEntries = count($dataLine);
                    echo "<th scope=\"row\">" . $row . "</th>";
                    $row++;
                    for ($counter=0; $counter < $numEntries; $counter++) {
                        echo "<td>".  $dataLine[$counter] . "</td>";
                    }
                    echo "</tr>";
                }
                fclose($readLines);
            }
//            var_dump($readLines);
            ?>
            </tbody>
        </table>
</body>
</html>


<?php
require_once 'public/footer.php';
?>
