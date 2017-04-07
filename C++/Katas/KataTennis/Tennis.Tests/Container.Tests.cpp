#include "stdafx.h"
#include <gtest/gtest.h>
#include <memory>
#include "Container.h"
#include "IContainerFactory.h"

class Item
{
public:
    Item ()
    {
    }
};

class ItemFactory
        : public Tennis::Logic::IContainerFactory<Item>
{
public:
    Item* create () override
    {
        return new Item();
    }

    void release ( Item* item ) override
    {
        delete item;
    }
};

class TestContainer
        : public Tennis::Logic::Container<Item, ItemFactory>
{
public:
    TestContainer ( std::unique_ptr<ItemFactory> factory )
        : Container<Item, ItemFactory> ( std::move ( factory ) )
    {
    }
};

std::unique_ptr<TestContainer> create_sut ()
{
    std::unique_ptr<ItemFactory> factory = std::make_unique<ItemFactory>();

    std::unique_ptr<TestContainer> sut = std::make_unique<TestContainer> ( std::move ( factory ) );

    return sut;
}

TEST(Container, new_item_returns_new_item)
{
    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    Item* actual = sut->new_item();

    // Assert
    EXPECT_NE(nullptr, actual);
}

TEST(Container, new_item_adds_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    sut->new_item();

    // Assert
    EXPECT_EQ(expected, sut->get_length());
}

TEST(Container, get_length_returns_number_of_items)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    sut->new_item();
    sut->new_item();

    // Act
    size_t actual = sut->get_length();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Container, get_current_item_returns_current_item)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    sut->new_item();

    // Act
    auto actual = sut->get_current_item();

    // Assert
    EXPECT_NE(nullptr, actual);
}

TEST(Container, operator_index_returns_set_for_first_index)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    Item* item_one = sut->new_item();
    sut->new_item();

    // Act
    Item* actual = ( *sut.get() ) [ 0 ];

    // Assert
    EXPECT_EQ(item_one, actual);
}

TEST(Container, operator_index_returns_set_for_second_index)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    sut->new_item();
    Item* set_two = sut->new_item();

    // Act
    Item* actual = ( *sut.get() ) [ 1 ];

    // Assert
    EXPECT_EQ(set_two, actual);
}

TEST(Container, operator_index_throws_for_invalid_index_negative)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    // Assert
    EXPECT_THROW(
        (*sut.get())[-1],
        Tennis::Logic::ContainerException);
}

TEST(Container, operator_index_throws_for_invalid_index_to_big)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    // Assert
    EXPECT_THROW(
        (*sut.get())[1000],
        Tennis::Logic::ContainerException);
}
