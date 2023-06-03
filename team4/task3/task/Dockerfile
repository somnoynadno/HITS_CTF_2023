FROM debian:bookworm-slim
WORKDIR /vuln-ssh-server
COPY ssh_server_fork ./

COPY libssh.so.4.5.1 /usr/lib/x86_64-linux-gnu/
RUN ln -s /usr/lib/x86_64-linux-gnu/libssh.so.4.5.1 /usr/lib/x86_64-linux-gnu/libssh.so.4 && \
    ln -s /usr/lib/x86_64-linux-gnu/libssh.so.4.5.1 /usr/lib/x86_64-linux-gnu/libssh.so

RUN apt update && \
    apt install -y openssh-client openssl

    
RUN ssh-keygen -t dsa -m pem -N "" -f host_dsa_key && \
    ssh-keygen -t rsa -m pem -N "" -f host_rsa_key && \
    ssh-keygen -t ecdsa -m pem -N "" -f host_ecdsa_key

    
CMD ["./ssh_server_fork", "-r", "host_rsa_key", "-e", "host_ecdsa_key", "-d", "host_dsa_key", "-f", "HITS{K-U-Z-C-O-KUZCO-KUZCO-GO-GO}", "-p", "2201", "0.0.0.0"]
