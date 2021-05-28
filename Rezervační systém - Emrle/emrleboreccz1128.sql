-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Počítač: sql5.webzdarma.cz:3306
-- Vytvořeno: Ned 21. bře 2021, 20:30
-- Verze serveru: 8.0.22-13
-- Verze PHP: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `emrleboreccz1128`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `objednane`
--

CREATE TABLE `objednane` (
  `id` int NOT NULL,
  `uziv_id` int DEFAULT NULL,
  `nabid_id` int DEFAULT NULL,
  `jmeno` text COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `nazev` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cena` int DEFAULT NULL,
  `datum` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Vypisuji data pro tabulku `objednane`
--

INSERT INTO `objednane` (`id`, `uziv_id`, `nabid_id`, `jmeno`, `email`, `nazev`, `cena`, `datum`) VALUES
(81, NULL, 4, 'Velký', 'junioremrle@seznam.cz', NULL, NULL, '5555-04-04'),
(92, NULL, 10, 'admin', 'junioremrle@seznam.cz', NULL, NULL, '2222-01-01'),
(128, NULL, 10, 'admin', 'junioremrle@seznam.cz', NULL, NULL, '5555-04-05'),
(132, NULL, 1, 'Michal', '273272@seznam.cz', NULL, NULL, '2022-11-10');

-- --------------------------------------------------------

--
-- Struktura tabulky `zvirata`
--

CREATE TABLE `zvirata` (
  `id` int NOT NULL,
  `fotkaproduktu` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `nazev` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cena` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Vypisuji data pro tabulku `zvirata`
--

INSERT INTO `zvirata` (`id`, `fotkaproduktu`, `nazev`, `cena`) VALUES
(1, 'https://www2.epochtimes.cz/images/stories/News/2017/12/20171222-husa.jpg', 'Česká husa', 400),
(2, './Tulska.jpg', 'Tulská Husa', 500),
(3, 'https://www.ploty-dops.cz/editor/filestore/Image/kategorie/shutterstock_320121680.jpg', 'Kur domácí', 450),
(4, 'https://www.stoplusjednicka.cz/sites/default/files/obrazky/2018/01/turkey.jpg', 'Krocan domácí', 700),
(5, 'https://www.zoozlin.eu/media/photos/animal/item/gallery/images-700/7af714820db6b543ad7a0132b057b9ab-t1.jpeg', 'Pštros dvouprstý', 2000),
(6, 'https://i.pinimg.com/originals/21/84/b2/2184b29eab345916a3b1d30f4f1b9c55.jpg', 'Velociraptor', 5000),
(7, 'https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/1971319-p201702070520601.jpeg?itok=Z-yPw3Qs', 'Blboun nejapný', 1000),
(8, 'http://cdn.gamer-network.net/2019/metabomb/murlocshamandecklistguidehearthstone.jpg', 'Murloc', 2200),
(9, 'https://www.herocollector.com/uploads/media/Wizarding-World-niffler-special-pic.gif', 'Ježek', 3000),
(10, './fury.jpg', 'Michal + Furry\r\n(double pack)', 369);

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `objednane`
--
ALTER TABLE `objednane`
  ADD PRIMARY KEY (`id`),
  ADD KEY `nabid_id` (`nabid_id`);

--
-- Klíče pro tabulku `zvirata`
--
ALTER TABLE `zvirata`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `objednane`
--
ALTER TABLE `objednane`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=158;

--
-- AUTO_INCREMENT pro tabulku `zvirata`
--
ALTER TABLE `zvirata`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `objednane`
--
ALTER TABLE `objednane`
  ADD CONSTRAINT `objednane_ibfk_1` FOREIGN KEY (`nabid_id`) REFERENCES `zvirata` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
