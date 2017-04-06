#include "stdafx.h"
#include <gtest/gtest.h>
#include <memory>
#include "Sets.h"
#include "MockISetFactory.h"
#include "MockISet.h"

TEST(Sets, create_new_set_returns_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<MockISet> mock_set = std::make_unique<MockISet>();
    std::shared_ptr<MockISetFactory> mock_set_factory = std::make_shared<MockISetFactory>();
    std::shared_ptr<ISetFactory> factory ( mock_set_factory );
    Sets sut { std::move ( factory ) };

    // Assert
    EXPECT_CALL(*mock_set_factory, create())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( mock_set.get() ) );

    // Act
    ISet* actual = sut.create_new_set();

    // Assert
    EXPECT_EQ(mock_set.get(), actual);
}

TEST(Sets, create_new_set_adds_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };

    std::unique_ptr<MockISet> mock_set = std::make_unique<MockISet>();
    std::shared_ptr<MockISetFactory> mock_set_factory = std::make_shared<MockISetFactory>();
    std::shared_ptr<ISetFactory> factory ( mock_set_factory );
    Sets sut { std::move ( factory ) };

    // Assert
    EXPECT_CALL(*mock_set_factory, create())
                                            .Times ( 1 )
                                            .WillOnce ( testing::Return ( mock_set.get() ) );

    // Act
    sut.create_new_set();

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

TEST(Sets, get_number_of_sets_returns_number_of_Sets)
{
    using namespace Tennis::Logic;

    // Arrange
    std::shared_ptr<MockISetFactory> mock_set_factory = std::make_shared<MockISetFactory>();
    std::shared_ptr<ISetFactory> factory ( mock_set_factory );
    Sets sut { std::move ( factory ) };
    sut.create_new_set();
    sut.create_new_set();

    // Act
    size_t actual = sut.get_number_of_sets();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Sets, get_current_set_returns_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<MockISet> mock_set = std::make_unique<MockISet>();
    std::shared_ptr<MockISetFactory> mock_set_factory = std::make_shared<MockISetFactory>();
    std::shared_ptr<ISetFactory> factory ( mock_set_factory );
    Sets sut { std::move ( factory ) };
    ISet* expected = sut.create_new_set();

    // Act
    auto actual = sut.get_current_set();

    // Assert
    EXPECT_EQ(expected, actual);
}
