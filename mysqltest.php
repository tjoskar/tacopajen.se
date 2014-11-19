<?php

$server = 'mysql13.citynetwork.se';
$database = '107372-tacopaj';
$user = '107372-zo70272';
$password = 'hundiparis5';
$conn = mysqli_connect($server, $user, $password, $database);

if (mysqli_connect_errno($con))
{
echo "Failed to connect to MySQL: " . mysqli_connect_error();
 }

mysqli_close($conn);
