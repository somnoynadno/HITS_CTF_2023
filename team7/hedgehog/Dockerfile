FROM gradle:jdk8
WORKDIR /opt/hedgehog
COPY . .
RUN gradle bootJar

FROM amazoncorretto:8-alpine
ENV FLAG=HITS{example_flag}
WORKDIR /opt/hedgehog
COPY --from=0 /opt/hedgehog/build/libs .
CMD java -jar hedgehog-0.0.1-SNAPSHOT.jar