﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CafeRating.CMD.Languages {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CafeRating.CMD.Languages.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Выберите кафе.
        /// </summary>
        internal static string ChooseCafe {
            get {
                return ResourceManager.GetString("ChooseCafe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на comment - Оставить комментарий какому-либо кафе.
        /// </summary>
        internal static string CommandComment {
            get {
                return ResourceManager.GetString("CommandComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Удалить комментарий.
        /// </summary>
        internal static string CommandDelete {
            get {
                return ResourceManager.GetString("CommandDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на exit - Выйти из приложения.
        /// </summary>
        internal static string CommandExit {
            get {
                return ResourceManager.GetString("CommandExit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на help - Вывод всех команд.
        /// </summary>
        internal static string CommandHelp {
            get {
                return ResourceManager.GetString("CommandHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Введите свой комментарий: .
        /// </summary>
        internal static string EnterComment {
            get {
                return ResourceManager.GetString("EnterComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Введите дату рождения (dd.mm.yyyy): .
        /// </summary>
        internal static string EnterDateTime {
            get {
                return ResourceManager.GetString("EnterDateTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Введите пол: .
        /// </summary>
        internal static string EnterGender {
            get {
                return ResourceManager.GetString("EnterGender", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Введите имя пользователя: .
        /// </summary>
        internal static string EnterName {
            get {
                return ResourceManager.GetString("EnterName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ваша оценка данного кафе от 1 до 5: .
        /// </summary>
        internal static string EnterRating {
            get {
                return ResourceManager.GetString("EnterRating", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Такого кафе нет.
        /// </summary>
        internal static string ErrorDoesNotExistCafe {
            get {
                return ResourceManager.GetString("ErrorDoesNotExistCafe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Неверный формат даты рождения.
        /// </summary>
        internal static string ErrorInvalidDateOfBirthFormat {
            get {
                return ResourceManager.GetString("ErrorInvalidDateOfBirthFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Неккоректный ввод.
        /// </summary>
        internal static string ErrorInvalidInput {
            get {
                return ResourceManager.GetString("ErrorInvalidInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Вас приветствует приложение CafeRating!.
        /// </summary>
        internal static string Hello {
            get {
                return ResourceManager.GetString("Hello", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Неизвестная команда!.
        /// </summary>
        internal static string UnknownCommand {
            get {
                return ResourceManager.GetString("UnknownCommand", resourceCulture);
            }
        }
    }
}
