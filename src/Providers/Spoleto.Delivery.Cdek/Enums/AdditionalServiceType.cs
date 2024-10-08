﻿using System.ComponentModel;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Дополнительный тип заказа.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29923975.html"/>
    /// </remarks>
    public enum AdditionalServiceType
    {
        /// <summary>
        /// СТРАХОВАНИЕ
        /// </summary>
        /// <remarks>Обеспечение страховой защиты посылки. Размер дополнительного сбора страхования вычисляется от размера объявленной стоимости отправления.</remarks>
        [Description("СТРАХОВАНИЕ")]
        INSURANCE,

        /// <summary>
        /// ДОСТАВКА В ВЫХОДНОЙ ДЕНЬ
        /// </summary>
        /// <remarks>Компания СДЭК осуществляет доставку и отправление документов и грузов в выходные и нерабочие дни.
        /// При доставке или отправлении документов или грузов в выходной день к базовому тарифу добавляется 300 руб.</remarks>
        [Description("ДОСТАВКА В ВЫХОДНОЙ ДЕНЬ")]
        DELIV_WEEKEND,

        /// <summary>
        /// ЗАБОР В ГОРОДЕ ОТПРАВИТЕЛЕ
        /// </summary>
        /// <remarks>Дополнительная услуга забора груза в городе отправителя, при условии, что тариф доставки с режимом «от склада» (не доступна для тарифов Посылка).</remarks>
        [Description("ЗАБОР В ГОРОДЕ ОТПРАВИТЕЛЕ")]
        TAKE_SENDER,

        /// <summary>
        /// ДОСТАВКА В ГОРОДЕ ПОЛУЧАТЕЛЕ
        /// </summary>
        /// <remarks>Дополнительная услуга доставки груза в городе получателя, при условии, что тариф доставки с режимом «до склада» (только для тарифов «Экономический», «Магистральный», «Магистральный супер-экспресс»).</remarks>
        [Description("ДОСТАВКА В ГОРОДЕ ПОЛУЧАТЕЛЕ")]
        DELIV_RECEIVER,

        /// <summary>
        /// ПРИМЕРКА НА ДОМУ
        /// </summary>
        /// <remarks>Курьер доставляет покупателю несколько единиц товара (одежда, обувь и пр.) для примерки.</remarks>
        [Description("ПРИМЕРКА НА ДОМУ")]
        TRYING_ON,

        /// <summary>
        /// ЧАСТИЧНАЯ ДОСТАВКА
        /// </summary>
        /// <remarks>Во время доставки товара покупатель может отказаться от одной или нескольких позиций, и выкупить только часть заказа.
        /// Если в заказе указано одно вложение, услуга не подключается.</remarks>
        [Description("ЧАСТИЧНАЯ ДОСТАВКА")]
        PART_DELIV,

        /// <summary>
        /// РЕВЕРС
        /// </summary>
        /// <remarks>Обратный заказ на доставку от получателя до отправителя. Например, подписанные документы.</remarks>
        [Description("РЕВЕРС")]
        REVERSE,

        /// <summary>
        /// ОПАСНЫЙ ГРУЗ
        /// </summary>
        /// <remarks>Кроме обычных документов и грузов, компания СДЭК готова доставить отправления, содержащие опасные грузы (кроме запрещенных к перевозке).
        /// В связи с определенным риском стоимость доставки грузов, относящихся к категории опасных, увеличивается в 1,5 раза.</remarks>
        [Description("ОПАСНЫЙ ГРУЗ")]
        DANGER_CARGO,

        /// <summary>
        /// УПАКОВКА 1
        /// </summary>
        /// <remarks>Стоимость коробки размером 310*215*280мм — 30 руб. (для грузов до 10 кг).</remarks>
        [Description("УПАКОВКА 1")]
        PACKAGE_1,

        /// <summary>
        /// УПАКОВКА 2
        /// </summary>
        /// <remarks>Стоимость коробки размером 430*310*280мм — 45 руб. (для грузов до 15 кг).</remarks>
        [Description("УПАКОВКА 2")]
        PACKAGE_2,

        /// <summary>
        /// ТЯЖЕЛЫЙ ГРУЗ
        /// </summary>
        /// <remarks>При отправке тяжелых грузов, если вес 1 места составляет от 75 до 200 кг, то тариф увеличивается на 18 руб за каждый килограмм,
        /// если вес 1 места более 200 кг, то тариф увеличивается на 25 руб. за каждый килограмм.
        /// Также возможен индивидуальный расчет стоимости доставки тяжелых грузов.
        /// Тарифы на такие отправления будут рассчитаны индивидуально и в короткие сроки (не более 1 рабочего дня) и могут быть значительно дешевле наших базовых тарифов.</remarks>
        [Description("ТЯЖЕЛЫЙ ГРУЗ")]
        HEAVY_CARGO,

        /// <summary>
        /// НЕГАБАРИТНЫЙ ГРУЗ
        /// </summary>
        /// <remarks>При доставке негабаритного отправления, размер одной из сторон которого превышает 1,5 м, тариф увеличивается на 60 % (если отправление рассчитывается не по объемному весу).
        /// При доставке негабаритного отправления, размер одной из сторон которого превышает 2,2 м, тариф увеличивается на 100 % (если отправление рассчитывается не по объемному весу).</remarks>
        [Description("НЕГАБАРИТНЫЙ ГРУЗ")]
        OVERSIZE_CARGO,

        /// <summary>
        /// ОЖИДАНИЕ БОЛЕЕ 15 МИН. У ПОЛУЧАТЕЛЯ
        /// </summary>
        /// <remarks>К приезду курьера Отправление должно быть подготовлено.
        /// По правилам компании СДЭК курьер может ожидать передачи или получения отправления не более 15 минут.
        /// В случаях, когда курьер дожидается приема или передачи Отправления более 15 минут, взимается дополнительный сбор в размере 170 рублей.</remarks>
        [Description("ОЖИДАНИЕ БОЛЕЕ 15 МИН. У ПОЛУЧАТЕЛЯ")]
        WAIT_FOR_RECEIVER,

        /// <summary>
        /// ОЖИДАНИЕ БОЛЕЕ 15 МИН. У ОТПРАВИТЕЛЯ
        /// </summary>
        [Description("ОЖИДАНИЕ БОЛЕЕ 15 МИН. У ОТПРАВИТЕЛЯ")]
        WAIT_FOR_SENDER,

        /// <summary>
        /// ХРАНЕНИЕ НА СКЛАДЕ
        /// </summary>
        /// <remarks>При необходимости наша компания предоставляет возможность хранения груза на складе.
        /// Для клиентов с типом договора "Интернет-магазин" хранение первые 14 дней — БЕСПЛАТНО, для остальных клиентов хранение первые 7 дней — БЕСПЛАТНО.
        /// Начиная с пятнадцатых / восьмых суток, плата за хранение осуществляется по следующим тарифам:
        /// стандартного отправления (1 место размером до 25*40*60см) - основной тариф 15 руб./место за 1 календарный день, включая выходные и праздничные дни;
        /// не стандартного отправления (1 место размером более 25*40*60см ) - основной тариф 30 руб./место за 1 календарный день, включая выходные и праздничные дни.</remarks>
        [Description("ХРАНЕНИЕ НА СКЛАДЕ")]
        WAREHOUSING,

        /// <summary>
        /// ПРОЧЕЕ
        /// </summary>
        /// <remarks>Дополнительный сбор от кредитного контроля СДЭК.</remarks>
        [Description("ПРОЧЕЕ")]
        ANOTHER,

        /// <summary>
        /// ПОВТОРНАЯ ПОЕЗДКА
        /// </summary>
        /// <remarks>Когда требуется повторный вызов курьера по ранее аннулированному заказу либо доставка/забор не были осуществлены по вине клиента, начисляется дополнительный сбор.
        /// Размер сбора зависит от веса отправления и стоимости доставки по городу.</remarks>
        [Description("ПОВТОРНАЯ ПОЕЗДКА")]
        REPEATED_DELIVERY,

        /// <summary>
        /// ПЕНЯ
        /// </summary>
        /// <remarks>Дополнительный сбор от кредитного контроля СДЭК.</remarks>
        [Description("ПЕНЯ")]
        FINE,

        /// <summary>
        /// ОБРЕШЕТКА ГРУЗА
        /// </summary>
        /// <remarks>
        /// Деревянный каркас, (доска, брус) вокруг отправления, с боковыми вставками из деревянных реек.
        /// Стоимость обрешетки для каждого Отправления рассчитывается индивидуально. Т.е. это индивидуальная упаковка груза.
        /// Расчет стоимости производится по самой длинной стороне груза
        /// </remarks>
        [Description("ОБРЕШЕТКА ГРУЗА")]
        GRID_TREE,

        /// <summary>
        /// АРЕНДА КУРЬЕРА
        /// </summary>
        /// <remarks>
        /// Когда необходимо доставить или принять документы в Федеральные службы, такие как: налоговые органы, министерства, посольства, суды, службы надзора и т.д., а также по заказам, требующим ожидания более часа, наша компания готова предоставить курьера.
        /// Стоимость услуги 170 руб./ час, минимальная оплата за 3 часа (510 руб).
        /// </remarks>
        [Description("АРЕНДА КУРЬЕРА")]
        COURIER_SERVICE,

        /// <summary>
        /// УВЕДОМЛЕНИЕ О ВРУЧЕНИИ ЗАКАЗА
        /// </summary>
        /// <remarks>
        /// Компания СДЭК предлагает каждому клиенту оформить услугу "СМС-уведомление о доставке".
        /// Отправителю высылается сообщение с датой и временем доставки. Стоимость услуги 10 рублей.
        /// Отправитель получает СМС-сообщение с информацией о дате/времени доставки и ФИО получателя. При режиме доставки до склада и указании мобильного телефона получателя, Компания "СДЭК" предоставляет всем клиентам бесплатную услугу: "СМС-уведомление о приходе груза на склад" или уведомления в виде PUSH-сообщений в мобильное приложение СДЭК или в месседжеры. Получателю будет отправлено сообщение с информацией об адресе забора отправления и времени работы офиса.
        /// </remarks>
        [Description("УВЕДОМЛЕНИЕ О ВРУЧЕНИИ ЗАКАЗА")]
        SMS,

        /// <summary>
        /// ПОДЪЕМ НА ЭТАЖ РУЧНОЙ
        /// </summary>
        /// <remarks>
        /// Услуга предоставляется при необходимости подъема на этаж крупногабаритных и тяжелых отправлений (весом от 10 кг).
        /// Разделяется на 2 вида: «Подъем на этаж ручной» и «Подъем на этаж лифтом».
        /// Стоимость услуги «Подъем на этаж ручной» (без лифта)
        /// для веса до 30 кг включительно — 50 руб. каждый этаж
        /// для веса 31-50 кг — 70 руб. каждый этаж
        /// для веса 51-100 кг — 100 руб. каждый этаж
        /// для веса 101-150 кг — 130 руб. каждый этаж
        /// для веса свыше 150 кг — 150 руб. каждый этаж
        /// Стоимость услуги «Подъем на этаж лифтом»:
        /// для веса до 30 кг включительно — 50 руб.
        /// для веса 31-50 кг — 70 руб.
        /// для веса 51-100 кг — 100 руб.
        /// для веса 101-150 кг — 130 руб.
        /// для веса свыше 100 кг — 150 руб.
        /// </remarks>
        [Description("ПОДЪЕМ НА ЭТАЖ РУЧНОЙ")]
        GET_UP_FLOOR_BY_HAND,

        /// <summary>
        /// ПОДЪЕМ НА ЭТАЖ ЛИФТОМ
        /// </summary>
        /// <remarks>
        /// Услуга предоставляется при необходимости подъема на этаж крупногабаритных и тяжелых отправлений (весом от 10 кг).
        /// Разделяется на 2 вида: «Подъем на этаж ручной» и «Подъем на этаж лифтом».
        /// Стоимость услуги «Подъем на этаж лифтом»:
        /// для веса до 30 кг включительно — 50 руб.
        /// для веса 31-50 кг — 70 руб.
        /// для веса 51-100 кг — 100 руб.
        /// для веса 101-150 кг — 130 руб.
        /// для веса свыше 100 кг — 150 руб.
        /// </remarks>
        [Description("ПОДЪЕМ НА ЭТАЖ ЛИФТОМ")]
        GET_UP_FLOOR_BY_ELEVATOR,

        /// <summary>
        /// ПРОЗВОН
        /// </summary>
        /// <remarks>
        /// Услуга для ИМ "Прозвон" включает в себя предварительный прозвон получателей перед доставкой операторами call-центра. Стоимость услуги 15 руб. 1 заказ.
        /// </remarks>
        [Description("ПРОЗВОН")]
        CALL,

        /// <summary>
        /// ТЕПЛОВОЙ РЕЖИМ
        /// </summary>
        /// <remarks>
        /// Направления, по которым возможна доставка с тепловым режимом: Кемерово-Новокузнецк, Новосибирск-Красноярск, Новосибирск-Кемерово, Новосибирск-Томск, Новосибирск-Омск, Новосибирск-Барнаул, Барнаул-Горно-Алтайск И В ОБРАТНЫХ НАПРАВЛЕНИЯХ!
        /// </remarks>
        [Description("ТЕПЛОВОЙ РЕЖИМ")]
        THERMAL_MODE,

        /// <summary>
        /// АГЕНТСКОЕ ВОЗНАГРАЖДЕНИЕ
        /// </summary>
        /// <remarks>
        /// Наша компания оказывает услуги по приему денежных средств от клиента за товар и РКО.
        /// </remarks>
        [Description("АГЕНТСКОЕ ВОЗНАГРАЖДЕНИЕ")]
        AGENT_COMMISSION,

        /// <summary>
        /// Пакет курьерский А2
        /// </summary>
        /// <remarks>
        /// Размер пакета - 495х580+50,
        /// Вес - до 5 кг,
        /// Стоимость - 70 руб.
        /// 3-х слойный полиэтилен, 55 мкм, ширина клапана 50/40, клеевой клапан, с системой защиты от вскрытия, уникальный номер ШК, для идентификации. Внутреннее покрытие черное, защищает от сквозного просвечивания.
        /// </remarks>
        [Description("Пакет курьерский А2")]
        COURIER_PACKAGE_A2,

        /// <summary>
        /// Сейф пакет А2
        /// </summary>
        /// <remarks>
        /// Размер пакета - 495х590+50,
        /// Вес - до 5 кг,
        /// Стоимость - 50 руб.
        /// 3-х слойный полиэтилен, 60 мкм, ширина клапана 50/50/40/40, индикаторная лента для защиты от несанкционированного вскрытия, уникальный номер ШК, для идентификации. Внутреннее покрытие черное, защищает от сквозного просвечивания.
        /// </remarks>
        [Description("Сейф пакет А2")]
        SECURE_PACKAGE_A2,

        /// <summary>
        /// Сейф пакет А3
        /// </summary>
        /// <remarks>
        /// Размер пакета - 335х460+50,
        /// Вес - до 3 кг,
        /// Стоимость - 40 руб.
        /// </remarks>
        [Description("Сейф пакет А3")]
        SECURE_PACKAGE_A3,

        /// <summary>
        /// Уведомление о создании заказа в СДЭК
        /// </summary>
        /// <remarks>
        /// Уведомление получателя по СМС о создании заказа в СДЭК.
        /// Применяется при создании заказа.
        /// При добавлении доп. услуги, номер для уведомлений будет браться из переданных данных получателя. Актуальную стоимость уточняйте у закреплённого менеджера.
        /// </remarks>
        [Description("Уведомление о создании заказа в СДЭК")]
        NOTIFY_ORDER_CREATED,

        /// <summary>
        /// Уведомление о приеме заказа на доставку
        /// </summary>
        /// <remarks>
        /// СМС-оповещение о доставке на мобильный телефон. 
        /// При добавлении доп. услуги, номер для уведомлений будет браться из переданных данных получателя. 
        /// Актуальную стоимость уточняйте у закреплённого менеджера.
        /// </remarks>
        [Description("Уведомление о приеме заказа на доставку")]
        NOTIFY_ORDER_DELIVERY,

        /// <summary>
        /// Коробка XS (0,5 кг 17х12х9 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 170*125*95 мм. Максимальная вместимость - 0,5 кг.
        /// Стоимость 1 штуки - 20 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка XS (0,5 кг 17х12х9 см)")]
        CARTON_BOX_XS,

        /// <summary>
        /// Коробка S (2 кг 21х20х11 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 216*200*110 мм. Максимальная вместимость - 2 кг.
        /// Стоимость 1 штуки - 40 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка S (2 кг 21х20х11 см)")]
        CARTON_BOX_S,

        /// <summary>
        /// Коробка M (5 кг 33х25х15 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 330*250*155 мм. Максимальная вместимость - 5 кг.
        /// Стоимость 1 штуки - 60 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка M (5 кг 33х25х15 см)")]
        CARTON_BOX_M,

        /// <summary>
        /// Коробка L (12 кг 34х33х26 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 340*330*264 мм. Максимальная вместимость - 12 кг.
        /// Стоимость 1 штуки - 70 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка L (12 кг 34х33х26 см)")]
        CARTON_BOX_L,

        /// <summary>
        /// Коробка (0,5 кг 17х12х10 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 170*120*100 мм. Максимальная вместимость - 0,5 кг.
        /// Стоимость 1 штуки - 35 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка (0,5 кг 17х12х10 см)")]
        CARTON_BOX_500GR,

        /// <summary>
        /// Коробка (1 кг 24х17х10 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 240*170*100 мм. Максимальная вместимость - 1 кг.
        /// Стоимость 1 штуки - 50 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка (1 кг 24х17х10 см)")]
        CARTON_BOX_1KG,

        /// <summary>
        /// Коробка (2 кг 34х24х10 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 340*240*100 мм. Максимальная вместимость - 2 кг.
        /// Стоимость 1 штуки - 80 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка (2 кг 34х24х10 см)")]
        CARTON_BOX_2KG,

        /// <summary>
        /// Коробка (3 кг 24х24х21 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 240*240*210 мм. Максимальная вместимость - 3 кг.
        /// Стоимость 1 штуки - 90 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка (3 кг 24х24х21 см)")]
        CARTON_BOX_3KG,

        /// <summary>
        /// Коробка (5 кг 40х24х21 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 400*240*210 мм. Максимальная вместимость - 5 кг.
        /// Стоимость 1 штуки - 100 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка (5 кг 40х24х21 см)")]
        CARTON_BOX_5KG,

        /// <summary>
        /// Коробка (10 кг 40х35х28 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 400*350*280 мм. Максимальная вместимость - 10 кг.
        /// Стоимость 1 штуки - 150 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Коробка (10 кг 40х35х28 см)")]
        CARTON_BOX_10KG,

        /// <summary>
        /// Коробка (15 кг 60х35х29 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 600*350*290 мм. Максимальная вместимость - 15 кг.
        /// Стоимость 1 штуки - 190 рублей.
        /// Доступна для всех тарифов от склада (кроме режима <see cref="ServiceCode.WarehouseToPostamat"/>).
        /// </remarks>
        [Description("Коробка (15 кг 60х35х29 см)")]
        CARTON_BOX_15KG,

        /// <summary>
        /// Коробка (20 кг 47х40х43 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 470*400*430 мм. Максимальная вместимость - 20 кг.
        /// Стоимость 1 штуки - 200 рублей.
        /// Доступна для всех тарифов от склада (кроме режима <see cref="ServiceCode.WarehouseToPostamat"/>).
        /// </remarks>
        [Description("Коробка (20 кг 47х40х43 см)")]
        CARTON_BOX_20KG,

        /// <summary>
        /// Коробка (30 кг 69х39х42 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 690*390*420 мм. Максимальная вместимость - 30 кг.
        /// Стоимость 1 штуки - 250 рублей.
        /// Доступна для всех тарифов от склада (кроме режима <see cref="ServiceCode.WarehouseToPostamat"/>).
        /// </remarks>
        [Description("Коробка (30 кг 69х39х42 см)")]
        CARTON_BOX_30KG,

        /// <summary>
        /// Воздушно-пузырчатая пленка
        /// </summary>
        /// <remarks>
        /// Стоимость за 1 метр - 55 рублей.
        /// Является дополнительным упаковочным материалом для упаковки отправлений в транспортную упаковку: деревянная обрешетка, гофрокороб, тубусы, пакеты курьерские и т.д.
        /// Функциональное назначение материала:
        /// - амортизация, защита от вибрации, механических ударов, трения и повреждений при падении;
        /// - заполнение пустот, внутри упаковки;
        /// - защита от пыли, грязи и влаги.
        /// </remarks>
        [Description("Воздушно-пузырчатая пленка")]
        BUBBLE_WRAP,

        /// <summary>
        /// Макулатурная бумага
        /// </summary>
        /// <remarks>
        /// Упаковочная бумага (макулатурная, класса Е). Ширина 0,42 м. Предназначена для упаковки различных видов отправлений (грузов) и заполнения пустот внутри упаковки.
        /// Стоимость за 1 метр - 50 рублей.
        /// Доступна для всех тарифов от склада.
        /// </remarks>
        [Description("Макулатурная бумага")]
        WASTE_PAPER,

        /// <summary>
        /// Прессованный картон "филлер" (55х14х2,3 см)
        /// </summary>
        /// <remarks>
        /// Размер - 550х140х23 мм, 
        /// Стоимость - 50 руб.
        /// Вставка защитная из листового прессованного картона "филлер". ЭКО материал.
        /// Применяется для:
        /// - внутренней обрешетки внутри гофрокороба;
        /// - оборачивания и разделения вложений внутри гофрокороба;
        /// - заполнения пустот.
        /// Состав материала:
        /// Биоразлагаемый материал, выполнен из вторично переработанной макулатуры и воды.
        /// Особенность материала:
        /// Высокая надежность и сопротивляемость механическим нагрузкам, за счет прочности объемной конструкции "филлера"
        /// Защита предметов любой формы. Удобно создавать во круг предмета защитный "чехол", скрепляя между собой "ячейки" в замок.
        /// </remarks>
        [Description("Прессованный картон \"филлер\" (55х14х2,3 см)")]
        CARTON_FILLER,

        /// <summary>
        /// Запрет осмотра вложения
        /// </summary>
        /// <remarks>
        /// Предоставляет возможность запрета осмотра вложения. Предоставляется для интернет-магазинов.
        /// Не совместима с доп.услугами <see cref="ServiceCode.FittingAtHome"/> и <see cref="ServiceCode.PartialDelivery"/>.
        /// Услуга не передается до постамата.
        /// Стоимость - 0 рублей.
        /// </remarks>
        [Description("Запрет осмотра вложения")]
        BAN_ATTACHMENT_INSPECTION,

        /// <summary>
        /// Фото документов
        /// </summary>
        /// <remarks>
        /// Предназначена для выполнения доставок продуктов (грузы, документы), с идентификацией получателя, фотографированием товара клиента/подписанных документов.
        /// Услуга платная, условия уточняйте у своего менеджера.
        /// </remarks>
        [Description("Фото документов")]
        PHOTO_OF_DOCUMENTS,

        /// <summary>
        /// Онлайн сбор
        /// </summary>
        /// <remarks>
        /// Дополнительный сбор по заказу.
        /// Выбрать нельзя, начисляется СДЭКом.
        /// </remarks>
        [Description("Онлайн сбор")]
        CASH_ON_DELIVERY,

        /// <summary>
        /// Перемещение на ПВЗ
        /// </summary>
        /// <remarks>
        /// Услуга по перемещению заказа на ПВЗ. Недоступна для выбора при регистрации заказа, добавляется СДЭК при смене режима доставки с "до двери" на "до склада".
        /// </remarks>
        [Description("Перемещение на ПВЗ")]
        MOVING_TO_WAREHOUSE,

        /// <summary>
        /// Конверт А4 из картона (бесплатный)
        /// </summary>
        /// <remarks>
        /// Бесплатный конверт A4 из картона.
        /// </remarks>
        [Description("Конверт А4 из картона (бесплатный)")]
        ENVELOPE_A4_CDEK_FREE,

        /// <summary>
        /// Коробка XL
        /// </summary>
        /// <remarks>
        /// Картонная коробка (18 кг).
        /// </remarks>
        [Description("Коробка XL")]
        CARTON_BOX_XL_18_KILOS,

        #region Типы услуг из раздела "Регистрация заказа" https://api-docs.cdek.ru/29923926.html

        /// <summary>
        /// Коробка S (2 кг 23х19х10 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 216*200*110 мм. Максимальная вместимость - 2 кг.<br/>
        /// Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат
        /// </remarks>
        [Description("Коробка S (2 кг 23х19х10 см)")]
        CARTON_BOX_S_2_KILOS,

        /// <summary>
        /// Коробка L (12 кг 31х25х38 см)
        /// </summary>
        /// <remarks>
        /// Коробка из трехслойного гофрокартона размером 340*330*264 мм. Максимальная вместимость - 12 кг.<br/>
        /// Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат
        /// </remarks>
        [Description("Коробка L (12 кг 31х25х38 см)")]
        CARTON_BOX_L_12_KILOS,

        /// <summary>
        /// 18+
        /// </summary>
        /// <remarks>
        /// Сервис проверки возраста получателя (товары 18+).<br/>
        /// Услуга предлагается в доступных только при наличии в договоре признака 18+
        /// </remarks>
        [Description("18+")]
        ADULT_GOODS,

        /// <summary>
        /// Погрузо-разгрузочные работы у отправителя
        /// </summary>
        /// <remarks>
        /// Погрузка и разгрузка по адресу клиента, если вес грузовых мест не превышает 80 кг.<br/>
        /// Доп. услуга доступна только для тарифов:<br/>
        /// Магистральный супер-экспресс<br/>
        /// Магистральный экспресс<br/>
        /// Сборный груз<br/>
        /// Экономичная посылка<br/>
        /// Экспресс<br/>
        /// </remarks>
        [Description("Погрузо-разгрузочные работы у отправителя")]
        LOADING_OPERATIONS_AT_THE_SENDER,

        /// <summary>
        /// Погрузо-разгрузочные работы у получателя
        /// </summary>
        /// <remarks>
        /// Погрузка и разгрузка по адресу клиента, если вес грузовых мест не превышает 80 кг.<br/>
        /// Доп. услуга доступна только для тарифов:<br/>
        /// Магистральный супер-экспресс<br/>
        /// Магистральный экспресс<br/>
        /// Сборный груз<br/>
        /// Экономичная посылка<br/>
        /// Экспресс<br/>
        /// </remarks>
        [Description("Погрузо-разгрузочные работы у получателя")]
        LOAD_THE_OPERATION_AT_THE_RECIPIENT,

        #endregion
    }
}