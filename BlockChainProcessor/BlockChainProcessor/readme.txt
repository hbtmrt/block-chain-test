Blockchain even stream processor
Project Structure
BlockChainProcessorThis project contains the main logic of the program.
BlockChainProcessor.CoreThis project contains the core logic, files that can be sharable across the solution.
Extensibility
ILogger This program has only ConsoleLogger. But the program can add more loggers in the future. We need to extend from ILogger class and implement the Write method. Then we need to do a tiny modification to the LoggerFactory class to add a new instance of the new class.

ICommandProcessor -- This program has few command processors to handle each command type, namely,  -- ReadLineCommandProcessor: handles --read-inline requests -- ReadFileCommandProcessor: handles --read-file requests -- NftOwnershipCommandProcessor - handles NFT commands -- WalletOwnershipCommandProcessor - handles wallet commands -- ResetCommandProcessor - handles reset command. -- New commands can be easily added by extending ICommandProcessor.

ITransactionExcecutor -- This program has few transaction types -- Mint - Adding blocks to the wallet -- Burn - remove the block -- Transfer - Remove block from the wallet and add it to another. -- New transaction types can be easily added by extending ITransactionExcecutor

Assumptions
The program requires the following format to execute commands."program - -reset" -- "program" keyword is required. -- "- -" before every command- Some test results given in the test document are most likely to be wrong therefore, I made that assumption and continued the development [Example][https://drive.google.com/file/d/17dMpDYA6SF58Vw8IgsaTooXgL5wKf0Zc]
Special Notes
The following command given in the test document will not be excecuted as it is not valid. (-nft should be - -nft)program -nft 0xC000000000000000000000000000000000000000
This project has used the Factory method pattern to create objects in one place.
And also, this project used the strategy pattern for future implementation.
And singleton pattern also has been used for some classes to make sure it creates only one instance throughout the project.
Some custom exception class has been added to handle specific errors.