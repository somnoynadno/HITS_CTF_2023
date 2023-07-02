FROM gradle:jdk8
WORKDIR /opt/hedgehog
COPY . .
RUN gradle bootJar

FROM amazoncorretto:8-alpine
ENV FlAG=HITS{s8p3r_f8l0_i8_t1e_w0r1d}
WORKDIR /opt/hedgehog
COPY --from=0 /opt/hedgehog/build/libs .
CMD java -jar hedgehog-0.0.1-SNAPSHOT.jar
