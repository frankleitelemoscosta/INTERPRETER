all: 

	mcs ./src/*.cs ./src/interpreter/command/*.cs ./src/interpreter/expr/*.cs ./src/interpreter/util/*.cs ./src/lexico/*.cs ./src/syntatic/*.cs -out:./bin/executavel.exe

clean: 

	rm -rf ./bin/executavel.exe

run: 

	mono ./bin/executavel.exe ./examples/pot.tiny

c: clean all run 
