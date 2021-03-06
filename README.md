# Dotnet簡介

## MVC介紹

1. 透過Model更新View，使用者透過View介面查看更新資訊
2. 使用Controller控制Model
3. View介面大多使用JS撰寫，可透過API結合前端JS、Angular等創造使用者觀看介面
4. 使用者透過View操作Controller更新Model，藉此循環

![image-20210223160542716](Images/image-20210223160542716.png)

# 開始

## 第一步 (創建新增、刪除、修改、查詢方法)

1. 創建Model資料夾，裡面創建各種會使用到的分類，例如 : 角色資料-指定角色屬性

2. 創建Controller來控制Model裡的參數

   ![image-20210223164340142](Images/image-20210223164340142.png)

3. 將方法修改下，改成使用ID呼叫角色資料

   ![image-20210223165344478](Images/image-20210223165344478.png)

4. 添加查詢方法，透過HttpPost與Json格式傳遞資料(利用PostMan功能)

   ![image-20210224114109284](Images/image-20210224114109284.png)

5. 為了整合功能，創建資料夾 Services / CharacterService / CharacterService.cs , ICharacterService.cs

   1. ICharacterService為介面(Interface)，裡面定義需要的功能並由Class去繼承並實作

      ![image-20210224122520510](Images/image-20210224122520510.png)

   2. CharavterService類別繼承ICharacterService並實作其功能

      ![image-20210224123115851](Images/image-20210224123115851.png)

      > 介面(Interface)就類似於老闆，出一張嘴要你與客戶簽約、談需求、設計產品、提供服務等，而需要一個類別(Class)等同於員工去實作，當類別繼承介面後，如沒有實作完全部方法，編譯器會報錯

   3. 建立完後需到Startup.cs中添加引用外部服務，系統只承認Controller內的功能，如引用到外部資料須至Startup內宣告

      ![image-20210224123924339](Images/image-20210224123924339.png)

   4. 需在其中加上Task，並等待資料回傳，在CharacterController、CharacterService中加入async (先知道就好C#異步開發再找時間學)

      https://docs.microsoft.com/zh-tw/dotnet/api/system.threading.tasks.task?view=net-5.0

      ![image-20210224142612692](Images/image-20210224142612692.png)

      ![image-20210224142742740](Images/image-20210224142742740.png)

      ![image-20210224142930911](Images/image-20210224142930911.png)

6. 建立Model / ServiceResponse.cs，用於顯示資料回傳狀態

   1. 建立一個 泛型Class 接收回傳資料

      ![image-20210224161135014](Images/image-20210224161135014.png)

   2. 在CharacterService,ICharacterService中的 Task<> 內加入ServiceResponse資料型態

      > 實作ServiceResponse接收並回傳資料，替代原本的newCharacter回傳值 (黃底部分)

      ![image-20210224161851855](Images/image-20210224161851855.png)

      ![image-20210224162132982](Images/image-20210224162132982.png)

   3. 創建 Dtos/GetCharacterDto,AddCharacterDto，此目的用於接收伺服端的回傳資料，而不讓使用者直接獲取伺服端的值

      ![image-20210224163110881](Images/image-20210224163110881.png)

   4. 並更改ICharacterService,CharacterService,CharacterController中Task<>的資料型別

      ![image-20210224170719611](Images/image-20210224170719611.png)

      ![image-20210224170940698](Images/image-20210224170940698.png)

   5. 安裝AutoMapper封包，dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
      會多出一個與專案名稱相同的.csproj檔案，代表成功

      ![image-20210224171744305](Images/image-20210224171744305.png)

      ![image-20210224171912907](Images/image-20210224171912907.png)

   6. 並在Startup.cs中注入AutoMapper使用

      ![image-20210224172541653](Images/image-20210224172541653.png)

   7. 創建並使用AutoMapper參數替代CharacterController.cs中的參數

      ![image-20210224173854236](Images/image-20210224173854236.png)

   8. 創建一個分類AutoMapperProfile所需的參數連結再一起

      ![image-20210224180247824](Images/image-20210224180247824.png)

   9. 修改CharacterService內的Add方法

      ![image-20210224180721218](Images/image-20210224180721218.png)
      
   10. 建立修改角色方法
   
       1. 新增介面
   
       2. 實作介面
   
       3. 修改參數
   
       4. 如果修改角色的ID不相匹配的話會報錯，所以使用try-catch方式接收錯誤訊息防止系統崩潰
   
       5. 到CharacterController中新增修改角色Route定義為HttpPut，並修改頁面回傳狀態為 error 404,預設是200 OK
   
          ![image-20210225121020331](Images/image-20210225121020331.png)
   
       ![image-20210225120638072](Images/image-20210225120638072.png)
   
       ![image-20210225121849856](Images/image-20210225121849856.png)
   
   11. 建立刪除方法
   
       1. 新增介面
   
       2. 實作介面
   
       3. 添加功能
   
       4. 指定HttpDelete
   
          ![image-20210225132018460](Images/image-20210225132018460.png)
   
          ![image-20210225132307969](Images/image-20210225132307969.png)
   
          ![image-20210225132534548](Images/image-20210225132534548.png)

## 第二步 (創建資料庫)

1. 安裝 EFCore

   ![image-20210225144113173](Images/image-20210225144113173.png)

2. 安裝entity framework tool讓我們可以使用entity framework

   ![image-20210225144523999](Images/image-20210225144523999.png)
   
   ![image-20210225153558866](Images/image-20210225153558866.png)
   
3. 輸入 dotnet ef 指令啟動EF

   ![image-20210225153727333](Images/image-20210225153727333.png)

4. 下載SQL Server2019 Express

5. 設定登入檔(注意 : 在 appsettings.json內，不是appsetting.Development.json)

   ![image-20210308134431893](Images/image-20210308134431893.png)

   ![image-20210225175452653](Images/image-20210225175452653.png)
   
6. 創建連接動作，成功後會多出一個Migrations資料夾

   1. 連接

      ![image-20210308125006635](Images/image-20210308125006635.png)

   2. 創建資料庫，成功後開啟SQL可看見DB已建立

      ![image-20210308132812702](Images/image-20210308132812702.png)

      ![image-20210308134942193](Images/image-20210308134942193.png)

7. 新增服務功能用於接收DB回傳資料

   ![image-20210308150713511](Images/image-20210308150713511.png)

   ![image-20210308150858284](Images/image-20210308150858284.png)

   ![image-20210308151549032](Images/image-20210308151549032.png)

8. 修改服務內的程式碼

   1. 創建角色

      1. 刪除ID數量自動+1，SQL會自動給予資料主鍵ID

         ![image-20210308155235060](Images/image-20210308155235060.png)

      2. 添加await參數等待並接收回傳資料

         ![image-20210308155626635](Images/image-20210308155626635.png)

   2. 修改角色

      ![image-20210308171006298](Images/image-20210308171006298.png)

   3. 刪除角色

      1. 刪除用不到的程式碼

         ![image-20210308171127263](Images/image-20210308171127263.png)

      2. 修改並添加await參數

         ![image-20210308171420271](Images/image-20210308171420271.png)

## 第三步(創建使用者)

1. 建立使用者模型

   ![image-20210309143820128](Images/image-20210309143820128.png)

2. 建立資料表 輸入 : dotnet ef migrations add User

   ![image-20210309144709651](Images/image-20210309144709651.png)

3. 查看Migrations資料夾，出現User代表表單頁面生成，後輸入 : dotnet ef database update，經資料表建立進SQL中
   ![image-20210309145220511](Images/image-20210309145220511.png)

4. 加上關聯，一個使用者可以擁有個角色，建立完後輸入 dotnet ef database update，更新資料庫
   ![image-20210309160254138](Images/image-20210309160254138.png)
   ![image-20210309160907013](Images/image-20210309160907013.png)

5. 

