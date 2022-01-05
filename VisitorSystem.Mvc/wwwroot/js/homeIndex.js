$(document).ready(function () {
    // DataTable
 
    // DataTable

    // Chart.js
    const visitors = [
        {
            name: 'Eylül',
            viewCount: '500'
        },
        {
            name: 'Ekim',
            viewCount: '700'
        },
        {
            name: 'Kasım',
            viewCount: '800'
        },
        {
            name: 'Aralık',
            viewCount: '250'
        },
       
    ];


    let viewCountContext = $('#viewCountChart');

    let viewCountChart = new Chart(viewCountContext,
        {
            type: 'bar',
            data: {
                labels: visitors.map(visitor => visitor.name),
                datasets: [
                    {
                        label: 'Ziyaretçi Sayısı',
                        data: visitors.map(visitor => visitor.viewCount),
                        backgroundColor: 'blue',
                        hoverBorderWidth: 4,
                        hoverBorderColor: 'black'
                    }]
            },
            options: {
                plugins: {
                    legend: {
                        labels: {
                            font: {
                                size: 18
                            }
                        }
                    }
                }
            }
        });
});