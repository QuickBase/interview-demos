## Build and Run
The solution can be built and started in two different ways:
1. Create a 'uber' jar with `gradle uberJar` and run with: `java -jar build/libs/dev-interview-materials-uber.jar`
2. Build with `gradle build` and run with `java -cp "./build/classes/java/main:./build/resources/main:./lib/*" com.quickbase.Main`
   Notice that you should set the classpath correctly. Running the `copyDepJars` task will copy all required jars to the `lib` subdirectory.

### Output
The program prints out the aggregated data from both sources. When the log level is set to `DEBUG` it will inform you
when duplicated data is found, e.g. `Replacing country India from 1182105000 to 1210854977`.

## Tests
Several unit tests are added to cover the basic logic. Run them with `gradle test`.