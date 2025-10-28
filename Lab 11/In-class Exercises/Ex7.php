<?php
session_start();

// Check if the session variable exists; if not, set the start time
if (!isset($_SESSION['start_time'])) {
    $_SESSION['start_time'] = time();
}

// Calculate the number of seconds that have passed since the session started
$elapsed_time = time() - $_SESSION['start_time'];

// Check if 10 seconds have passed
if ($elapsed_time > 10) {
    // Destroy the session and reset the timer
    session_unset();        // Unset all session variables
    session_destroy();      // Destroy the session data on the server
    session_start();        // Start a new session
    $_SESSION['start_time'] = time();  // Reset the start time
    $elapsed_time = 1;      // Reset the elapsed time
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Page Auto Refresh Timer</title>
    <!-- Automatically refresh the page every 1 second -->
    <meta http-equiv="refresh" content="1">
</head>
<body>
    <h1>Page Auto Refresh Timer</h1>
    <p>Seconds since this tab was opened: <strong><?php echo $elapsed_time; ?></strong></p>
    <p>The page will refresh every second automatically.</p>
</body>
</html>