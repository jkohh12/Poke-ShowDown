mergeInto(LibraryManager.library, {
	SendData: function (json) {
        	const data = JSON.parse(UTF8ToString(json));

       		const type1Field = document.getElementById("type1");
        	const type2Field = document.getElementById("type2");
        	const type3Field = document.getElementById("type3");
        	const type4Field = document.getElementById("type4");
        
        	const move1Field = document.getElementById("move1");
        	const move2Field = document.getElementById("move2");
        	const move3Field = document.getElementById("move3");
        	const move4Field = document.getElementById("move4");

        	move1Field.innerText = data.move1;
        	move2Field.innerText = data.move2;
       		move3Field.innerText = data.move3;
        	move4Field.innerText = data.move4;

        	type1Field.innerText = data.type1;
        	type2Field.innerText = data.type2;
        	type3Field.innerText = data.type3;
        	type4Field.innerText = data.type4;


	},
});
		