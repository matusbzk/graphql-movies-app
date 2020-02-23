const apolloClient = new Apollo.lib.ApolloClient({
    networkInterface: Apollo.lib.createNetworkInterface({
        uri: 'https://localhost:44343/graphql'
    })
});

function renderAllPeople() {
    const query = Apollo.gql`
query renderAllPeople
{
	people {
    name
    birthDate
  }
}
    `;

    apolloClient.query({
        query: query
    }).then(result => {
        const div = document.getElementById("allPeople");
        result.data.people.forEach(person => {
            div.innerHTML += `
<div class="row">
    <div class="col-12"><h5>${person.name}</h5></div>
</div>
`;
        });
    });
}