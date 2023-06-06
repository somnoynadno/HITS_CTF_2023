<!DOCTYPE html>
<html>

<head>
	<!-- What is your favourite colour? Mine is blue! -->
	<title>❤️Stego Kitty❤️</title>
	<style>
		body {
			background: radial-gradient(ellipse at center, #363636 0%, #000000 100%);
			color: #ffffff;
		}

		img {
			cursor: pointer;
			border-radius: 50%;
			box-shadow: 0 2px 5px rgba(0, 0, 0, 0.8);
			border: 2px solid #fff;
			overflow: hidden;
		}

		table {
			width: 100%;
			table-layout: fixed;
			border-collapse: collapse;
			font-family: Arial, sans-serif;
		}

		thead {
			background-color: #232323;
		}

		th,
		td {
			padding: 8px;
			text-align: left;
			border-bottom: 1px solid #ddd;
		}

		tbody tr:nth-child(even) {
			background-color: #232323;
		}

		tbody tr:hover {
			background-color: #292929;
		}

		@media screen and (max-width: 600px) {
			table {
				font-size: 12px;
			}

			th,
			td {
				padding: 5px;
			}
		}
	</style>
</head>

<body>
	<h1 style="text-align: center;">❤️ Stego Kitty ❤️</h1>
	<div style="display: flex; justify-content: space-around; align-items: center;">
		<div style="text-align: center; margin: 10px;">
			<img src="janedoe.png"
				onclick="sendImage('janedoe.png')">
			<p style="margin-top: 5px; font-weight: bold;">🌼 Jane Doe</p>
		</div>

		<div style="text-align: center; margin: 10px;">
			<img src="johndoe.png"
				onclick="sendImage('johndoe.png')">
			<p style="margin-top: 5px; font-weight: bold;">⚔️ John Doe</p>
		</div>
	</div>
	<div id="response"></div>

	<script>
		function sendImage(imageName) {
			var xhttp = new XMLHttpRequest();
			xhttp.onreadystatechange = function () {
				if (this.readyState == 4 && this.status == 200) {
					function displayTable(data) {
						var table = document.createElement("table");
						table.id = "table";

						var thead = document.createElement("thead");
						var headerRow = document.createElement("tr");
						for (var key in data[0]) {
							var th = document.createElement("th");
							th.textContent = key;
							headerRow.appendChild(th);
						}
						thead.appendChild(headerRow);
						table.appendChild(thead);

						var tbody = document.createElement("tbody");
						data.forEach(function (obj) {
							var row = document.createElement("tr");
							for (var key in obj) {
								var cell = document.createElement("td");
								cell.textContent = obj[key];
								row.appendChild(cell);
							}
							tbody.appendChild(row);
						});
						table.appendChild(tbody);

						(document.getElementById("table") &&
							document.getElementById("table").remove())

						document.body.appendChild(table);
					}
					displayTable(JSON.parse(this.responseText));
				}
			};
			xhttp.open("POST", "api.php", true);
			xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
			xhttp.send("image=" + imageName);
		}
	</script>
</body>

</html>