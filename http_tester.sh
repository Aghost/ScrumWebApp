echo "HTTP Tester\nsupported tests:\n\tget\n\tpost"
echo "test which method?"

read answer
case $answer in
	"get") echo "GET"
		curl -X GET http://localhost:5000/api/ScrumTasksApi
		;;
	"post") echo "POST"
		#curl -d '{"taskName":"newtask1","status":0,"taskDescription":"task1description","createdOn":"2021-05-13T00:00:00", "updatedOn":"2021-05-13T00:10:00"}' -H "Content-Type: application/json" -X POST http://localhost:5000/api/ScrumTasksApi/

		#curl -d '{"taskName":"newtask2","status":1,"taskDescription":"task2description","createdOn":"2021-05-13T00:00:00", "updatedOn":"2021-05-14T00:10:00"}' -H "Content-Type: application/json" -X POST http://localhost:5000/api/ScrumTasksApi/
		;;
	*) echo "unrecognized" ;;
esac
