<?php
$acc = "hoopizs1452@gmail.com";
$pwd = "wtvu1245";
$path = escapeshellcmd("python ./verification.py $acc $pwd");
$output = shell_exec($path);

?>
