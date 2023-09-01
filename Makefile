all: 

	mcs ./src/main.cs ./src/Lexema.cs -out:./bin/executavel.exe

clean: 

	rm -rf ./bin/executavel.exe

run: 

	mono ./bin/executavel.exe
