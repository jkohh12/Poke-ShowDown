mergeInto(LibraryManager.library, {
	SendData: function (json) {
		const data = JSON.parse(UTF8ToString(json));
		
		const move1Field = document.getElementById("move1");
		const move2Field = document.getElementById("move2");
		const move3Field = document.getElementById("move3");
		const move4Field = document.getElementById("move4");

		move1Field.innerText = data.move1;
		move2Field.innerText = data.move2;
		move3Field.innerText = data.move3;
		move4Field.innerText = data.move4;
	},
});
		