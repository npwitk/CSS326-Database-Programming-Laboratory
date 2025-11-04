<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css" href="sticky.css">
</head>

<body>
	<form action="<?= $_SERVER["PHP_SELF"]?>" method="POST">
		<b>Title</b>: <input type="text" name="title" id="title" size="30" > <br><br>
		<b>Note</b>: <textarea name="note" cols="30" rows="5" ></textarea> <br>
		<input type="submit" value="Post!" name="submit" >
	</form>
	<hr>
	<!-- Put Display Content here -->
	
	<?php
	// Check if form was submitted
	if(isset($_POST['submit'])) {
		// Get the title and note from POST
		$title = $_POST['title'];
		$note = $_POST['note'];
		
		// Open file in append mode (creates file if it doesn't exist)
		// IMPORTANT: Replace XXX with last 3 digits of your student ID
		$file = fopen("sticky_note422.txt", "a");
		
		// Write title and note to file (each on separate line)
		fwrite($file, $title."\n");
		fwrite($file, $note."\n");
		
		// Close the file
		fclose($file);
	}
	?>
	
	<div class="post">
		<div class="title">
			<?php
			// Only execute after submit (check if submit is set in $_POST)
			if(isset($_POST['submit'])) {
				// Echo out the title from POST
				echo $_POST['title'];
			}
			?>
		</div>
		<div class="note">
			<?php
			// Only execute after submit (check if submit is set in $_POST)
			if(isset($_POST['submit'])) {
				// Echo out the note from POST
				echo $_POST['note'];
			}
			?>
		</div>
		<div class="notefoot">
			<?php
			// Only execute after submit (check if submit is set in $_POST)
			if(isset($_POST['submit'])) {
				// Open the file to count total number of notes
				// IMPORTANT: Replace XXX with last 3 digits of your student ID
				$file = fopen("sticky_note422.txt", "r");
				$count = 0;
				
				// Count lines in file (every 2 lines = 1 note: title + content)
				while(!feof($file)) {
					$line = fgets($file);
					if($line !== false && trim($line) !== '') {
						$count++;
					}
				}
				fclose($file);
				
				// Calculate number of notes (divide by 2 since each note has title + content)
				$notes = $count / 2;
				
				// Output: "X notes have been made"
				echo "$notes notes have been made";
			}
			?>
		</div>
	</div>
</body>

</html>
