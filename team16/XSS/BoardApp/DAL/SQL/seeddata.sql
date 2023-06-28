--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-05-28 16:55:55

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3341 (class 0 OID 49893)
-- Dependencies: 214
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: xss
--

INSERT INTO public.users VALUES ('c515b5f6-0843-4d99-86da-d08769a96c78', 'dima', 'BvNyfC7d6A');
INSERT INTO public.users VALUES ('a7ee48de-11bc-40c7-baa2-85944b756879', 'ilia', 'mg2FxFXTDd');
INSERT INTO public.users VALUES ('2faabcc4-6172-471b-ac9c-e172bb877999', 'cocker', 'tWG4p8NEHk');
INSERT INTO public.users VALUES ('3fca76e5-1e5a-46e9-b361-3119405e7d97', 'cum_enjoyer', 'pFmJQaKQCP');


--
-- TOC entry 3342 (class 0 OID 49900)
-- Dependencies: 215
-- Data for Name: boards; Type: TABLE DATA; Schema: public; Owner: xss
--

INSERT INTO public.boards VALUES ('59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'AMOGUS ERP 18+', 'c515b5f6-0843-4d99-86da-d08769a96c78', false);
INSERT INTO public.boards VALUES ('fcbedcc8-8ca1-47e5-b2c6-8ef8c7447fdc', 'Sex offender registry', 'a7ee48de-11bc-40c7-baa2-85944b756879', true);
INSERT INTO public.boards VALUES ('7fc0c328-c1f1-438f-afc5-bb13021ed832', 'totally not sussy board', '2faabcc4-6172-471b-ac9c-e172bb877999', true);
INSERT INTO public.boards VALUES ('d8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'BIG HONKERS', '3fca76e5-1e5a-46e9-b361-3119405e7d97', false);
INSERT INTO public.boards VALUES ('4e6b606e-f880-4af1-8194-a15c8053731c', 'Cybersafety enjoyers club', 'a7ee48de-11bc-40c7-baa2-85944b756879', false);


--
-- TOC entry 3343 (class 0 OID 49913)
-- Dependencies: 216
-- Data for Name: boardmembers; Type: TABLE DATA; Schema: public; Owner: xss
--

INSERT INTO public.boardmembers VALUES ('59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'c515b5f6-0843-4d99-86da-d08769a96c78');
INSERT INTO public.boardmembers VALUES ('fcbedcc8-8ca1-47e5-b2c6-8ef8c7447fdc', 'a7ee48de-11bc-40c7-baa2-85944b756879');
INSERT INTO public.boardmembers VALUES ('7fc0c328-c1f1-438f-afc5-bb13021ed832', '2faabcc4-6172-471b-ac9c-e172bb877999');
INSERT INTO public.boardmembers VALUES ('d8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', '3fca76e5-1e5a-46e9-b361-3119405e7d97');
INSERT INTO public.boardmembers VALUES ('d8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'c515b5f6-0843-4d99-86da-d08769a96c78');
INSERT INTO public.boardmembers VALUES ('59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', '3fca76e5-1e5a-46e9-b361-3119405e7d97');
INSERT INTO public.boardmembers VALUES ('59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'a7ee48de-11bc-40c7-baa2-85944b756879');
INSERT INTO public.boardmembers VALUES ('4e6b606e-f880-4af1-8194-a15c8053731c', 'a7ee48de-11bc-40c7-baa2-85944b756879');
INSERT INTO public.boardmembers VALUES ('4e6b606e-f880-4af1-8194-a15c8053731c', 'c515b5f6-0843-4d99-86da-d08769a96c78');
INSERT INTO public.boardmembers VALUES ('fcbedcc8-8ca1-47e5-b2c6-8ef8c7447fdc', 'c515b5f6-0843-4d99-86da-d08769a96c78');
INSERT INTO public.boardmembers VALUES ('7fc0c328-c1f1-438f-afc5-bb13021ed832', 'c515b5f6-0843-4d99-86da-d08769a96c78');
INSERT INTO public.boardmembers VALUES ('7fc0c328-c1f1-438f-afc5-bb13021ed832', 'a7ee48de-11bc-40c7-baa2-85944b756879');
INSERT INTO public.boardmembers VALUES ('7fc0c328-c1f1-438f-afc5-bb13021ed832', '3fca76e5-1e5a-46e9-b361-3119405e7d97');
INSERT INTO public.boardmembers VALUES ('d8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'a7ee48de-11bc-40c7-baa2-85944b756879');
INSERT INTO public.boardmembers VALUES ('4e6b606e-f880-4af1-8194-a15c8053731c', '2faabcc4-6172-471b-ac9c-e172bb877999');


--
-- TOC entry 3344 (class 0 OID 49926)
-- Dependencies: 217
-- Data for Name: messages; Type: TABLE DATA; Schema: public; Owner: xss
--

INSERT INTO public.messages VALUES ('993235ea-b418-4a37-a560-197dc60d221a', 'a7ee48de-11bc-40c7-baa2-85944b756879', 'fcbedcc8-8ca1-47e5-b2c6-8ef8c7447fdc', 'im not sex offender i swear');
INSERT INTO public.messages VALUES ('e29bd9c3-c338-4009-9ad7-c8afe893606d', 'a7ee48de-11bc-40c7-baa2-85944b756879', 'fcbedcc8-8ca1-47e5-b2c6-8ef8c7447fdc', 'i love cum');
INSERT INTO public.messages VALUES ('c46124cd-94b2-48de-ad0a-d3f6c4d74d06', '2faabcc4-6172-471b-ac9c-e172bb877999', '7fc0c328-c1f1-438f-afc5-bb13021ed832', 'I LOVE FORTNITE');
INSERT INTO public.messages VALUES ('1eb3b741-472d-49fa-b54f-9a9fef59e0bf', '2faabcc4-6172-471b-ac9c-e172bb877999', '7fc0c328-c1f1-438f-afc5-bb13021ed832', 'AND BOYS');
INSERT INTO public.messages VALUES ('318b1565-3bdf-4052-a47c-e15f0ab2a5ab', '3fca76e5-1e5a-46e9-b361-3119405e7d97', 'd8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'I LOVE BIG MOMMY MILKERs');
INSERT INTO public.messages VALUES ('f52cc721-db15-41ad-9f4d-d52ffb092807', '3fca76e5-1e5a-46e9-b361-3119405e7d97', 'd8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'LEMME SQUEEZE THOSE AWESOME BADONKERS');
INSERT INTO public.messages VALUES ('621054f7-1cec-4dd1-a29e-d89876b9dfb5', 'c515b5f6-0843-4d99-86da-d08769a96c78', 'd8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'get a (blow) job');
INSERT INTO public.messages VALUES ('de17e411-b84a-4dd2-9cb2-cd464a158dfb', 'c515b5f6-0843-4d99-86da-d08769a96c78', '59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'uwu owo im so ~~howny rn');
INSERT INTO public.messages VALUES ('fa9608d6-b24e-457d-a85f-017b6fe3febb', 'c515b5f6-0843-4d99-86da-d08769a96c78', '59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'daddy OwO');
INSERT INTO public.messages VALUES ('1841b4eb-037b-419e-955f-9dd65a9557b9', '3fca76e5-1e5a-46e9-b361-3119405e7d97', '59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'be patient kitten');
INSERT INTO public.messages VALUES ('313630bd-c920-410c-a0f9-a6191a300120', 'a7ee48de-11bc-40c7-baa2-85944b756879', '59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'oops wry wrong account');
INSERT INTO public.messages VALUES ('a0ec80b2-7905-4dca-b1e6-77f9a4886ba5', 'a7ee48de-11bc-40c7-baa2-85944b756879', '59b0fb1c-2c5a-4c3e-9b44-31980cfe0ae5', 'anyway');
INSERT INTO public.messages VALUES ('c9409fd9-8d3b-42b5-b671-3ab881998930', 'a7ee48de-11bc-40c7-baa2-85944b756879', '4e6b606e-f880-4af1-8194-a15c8053731c', 'i fucking hate cybersafety');
INSERT INTO public.messages VALUES ('ee2ea9dd-13eb-4fe4-9ae4-83efd99ee5f3', 'c515b5f6-0843-4d99-86da-d08769a96c78', '4e6b606e-f880-4af1-8194-a15c8053731c', '100% agree');
INSERT INTO public.messages VALUES ('c86c8e64-6942-4703-9932-58b2fa8dbcac', '3fca76e5-1e5a-46e9-b361-3119405e7d97', '7fc0c328-c1f1-438f-afc5-bb13021ed832', 'i love cum!');
INSERT INTO public.messages VALUES ('7cb06fae-2608-49c5-9c20-819353c1a57a', '3fca76e5-1e5a-46e9-b361-3119405e7d97', '7fc0c328-c1f1-438f-afc5-bb13021ed832', 'Xiàn zài wǒ yǒu bing chilling Wǒ hěn xǐ huān bing chilling Dàn shì "sù dù yǔ jī qíng jiǔ" bǐ bing chilling');
INSERT INTO public.messages VALUES ('194aa231-d096-4cf1-9a7f-53213303d481', 'a7ee48de-11bc-40c7-baa2-85944b756879', '7fc0c328-c1f1-438f-afc5-bb13021ed832', 'i am ilia and i hate n-');
INSERT INTO public.messages VALUES ('c8194049-1fbb-40f3-a281-569734585ae8', 'a7ee48de-11bc-40c7-baa2-85944b756879', 'd8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'Bro, I can''t stop looking at my big honkers');
INSERT INTO public.messages VALUES ('06757a74-5a0f-4eb1-9b0d-494d11995f95', 'a7ee48de-11bc-40c7-baa2-85944b756879', 'd8ac3f3f-63d5-4ed6-a552-89b28d0e93c5', 'Damn, That guy has some big city honkers! They''re bigger than most girls i''ve seen');
INSERT INTO public.messages VALUES ('aaded8ff-8772-4a25-a551-ccd4a5ec5ad6', '2faabcc4-6172-471b-ac9c-e172bb877999', '4e6b606e-f880-4af1-8194-a15c8053731c', 'Я не знаю, почему ты читаешь рэп');
INSERT INTO public.messages VALUES ('43b5fb62-03f1-4f03-b91c-b46f6aade2fa', '2faabcc4-6172-471b-ac9c-e172bb877999', '4e6b606e-f880-4af1-8194-a15c8053731c', 'Говоришь, что ты MC, но у тебя таланта нет ');
INSERT INTO public.messages VALUES ('145ebe9d-7824-4cdc-b1ad-ee4f1b91ef0a', '2faabcc4-6172-471b-ac9c-e172bb877999', '4e6b606e-f880-4af1-8194-a15c8053731c', 'Не знаю, почему я водкой запиваю воду');
INSERT INTO public.messages VALUES ('e2a4d7c3-b7bd-4e9b-b552-1cfb91852cd2', '2faabcc4-6172-471b-ac9c-e172bb877999', '4e6b606e-f880-4af1-8194-a15c8053731c', 'Зачем ты суёшь себе ');
INSERT INTO public.messages VALUES ('f31082dd-cd9d-435c-a4c4-8f951217f710', '2faabcc4-6172-471b-ac9c-e172bb877999', '4e6b606e-f880-4af1-8194-a15c8053731c', 'Почему цыгане моются, но все равно воняют?');


-- Completed on 2023-05-28 16:55:55

--
-- PostgreSQL database dump complete
--

