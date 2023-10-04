all: 

	mcs ./src/main.cs ./src/Lexema.cs ./src/TokenType.cs ./src/SymbolTable.cs ./src/LexicalAnalysis.cs -out:./bin/executavel.exe

clean: 

	rm -rf ./bin/executavel.exe

run: 

	mono ./bin/executavel.exe assign.tiny

c: clean all run 
